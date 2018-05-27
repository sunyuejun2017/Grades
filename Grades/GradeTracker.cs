using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grades
{
    /*
     * 抽象类和接口是两种API的定义方法，接口最灵活
     * 
     * 
     * 
     */



    /// <summary>
    /// 
    /// </summary>

    public interface IGradeTracker : IEnumerable
    { 
        void AddGrade(float grade);

        GradeStatistics ComputeStatistics();

        void WriteGrades(TextWriter textWriter);

        

        void DoSomething();

        string Name { get; set; }

         event NamedChangeDelegate NameChanged;

       
    }
    
    
    /// <summary>
    /// 声明GradeTracker抽象类
    /// 
    /// </summary>
    public abstract  class GradeTracker : IGradeTracker
    {
        // 定义抽象方法，提供哪些功能，这些抽象方法需要在用override来实现 
        public abstract void AddGrade(float grade);

        public abstract GradeStatistics ComputeStatistics();

        public abstract void WriteGrades(TextWriter textWriter);

        public abstract IEnumerator GetEnumerator();

        public abstract void DoSomething();
        
        private string _name;

        public string Name
        {
            get
            {
                return _name;
            }

            set
            {
                if (_name != value)
                {
                    var oldValue = _name;
                    _name = value;

                    if (NameChanged != null)
                    {
                        NameChangedEventArgs args = new NameChangedEventArgs();
                        args.OldValue = oldValue;
                        args.NewValue = value;

                        NameChanged(this, args);
                        //NameChanged(oldValue, value);
                    }
                }
            }

        }

        public event NamedChangeDelegate NameChanged;
    }
}
