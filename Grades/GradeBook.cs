﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace Grades
{
    public class GradeBook : GradeTracker 
    {
        public GradeBook(string name = null)
        {
            _name = name;
            grades = new List<float>();
        }


        public override IEnumerator GetEnumerator()
        {
            return grades.GetEnumerator();
        }

        public override void DoSomething()
        {
            Console.WriteLine("GradeBook Do something");
        }


        public override void AddGrade(float grade)
        {
            if (grade >= 0 && grade < 100)
            {
                grades.Add(grade);
            }
        }

        public override GradeStatistics ComputeStatistics()
        {
            GradeStatistics stats = new GradeStatistics();
            
            float sum = 0f;
            foreach (float grade in grades)
            {
                stats.HighestGrade = Math.Max(grade, stats.HighestGrade);
                stats.LowestGrade = Math.Min(grade, stats.LowestGrade);
                sum += grade;
            }

            stats.AverageGrade = sum / grades.Count;
            return stats;
        }

        public override void WriteGrades(TextWriter textWriter)
        {
            textWriter.WriteLine("Grades:");

            foreach (float _grade in grades)
            {
                Console.WriteLine(_grade);
            }
            textWriter.WriteLine("********");
        }

        private string _name;

        public string Name
        {
            get {
                return _name;
            }

            set {
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
        protected List<float> grades;
    }
}
