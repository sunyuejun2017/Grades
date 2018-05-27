using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Speech.Synthesis;
using System.IO;

namespace Grades
{
    class Program
    {
        static void GiveBookAName(ref GradeBook book)
        {
            //book = new GradeBook();
            //book.Name = "The New Gradebook";
        }

        static void IncrementNumber(ref int number)
        {
            number = 42;
        }

        static void Main(string[] args)
        {
           // SpeechSynthesizer synth = new SpeechSynthesizer();
            //synth.Speak("Hello, World");


            //Arrays();
            //Immutable();
            //PassByValueAndRef();

            GradeBook book = new GradeBook("Jack");

           

            
            try
            {

                using (FileStream fs = File.Open("grades.txt", FileMode.Open))
                using (StreamReader sr = new StreamReader(fs))
                {

                    string line = sr.ReadLine();

                    while (line != null)
                    {
                        float grade = float.Parse(line);
                        book.AddGrade(grade);
                        line = sr.ReadLine();
                    }

                }
                //string[] lines = File.ReadAllLines("grades.txt");

                //foreach (string line in lines)
                //{
                //    float grade = float.Parse(line);
                //    book.AddGrade(grade);
                //}
            }
            catch (FileNotFoundException ex)
            {

                Console.WriteLine("File not found");
                return;
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("No access");
                return;
            }
            //finally
            //{
            //    if (sr != null)
            //    {
            //        sr.Close();
            //    }

            //    if (fs != null)
            //    {
            //        fs.Close();
            //    }

            //}


            //book.AddGrade(91f);
            //book.AddGrade(89.1f);
            //book.AddGrade(75f);


            book.WriteGrades(Console.Out);

            //Console.WriteLine(book.Name);

            // Method 1 for delegate
            //book.NameChanged = new NamedChangeDelegate(OnNameChanged);

            // Method 2 for delegate
            //book.NameChanged += OnNameChanged;

            //book.NameChanged += OnNameChanged;
            //book.NameChanged += OnNameChanged2;
            //book.Name = "Dick";

            //Console.WriteLine(book.Name);

            //WriteNames("hello", "Jack", "bob", "Dick");

            GradeStatistics stats = book.ComputeStatistics();


            Console.WriteLine(stats.LetterGrade);

            Console.WriteLine(stats.Description);

            //int number = 20;

            //WriteBytes(number);
            //WriteBytes(stats.AverageGrade);


            //Console.WriteLine(stats.AverageGrade);
            //Console.WriteLine(stats.LowestGrade);
            //Console.WriteLine(stats.HighestGrade);

            Console.ReadKey();

        }

        private static void OnNameChanged2(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("*********");
        }

        private static void OnNameChanged(object sender, NameChangedEventArgs args)
        {
            Console.WriteLine("Name changed from {0} to {1}", args.OldValue, args.NewValue);

        }

        private static void WriteBytes(int value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            WrieByteArray(bytes);
        }

        

        private static void WriteBytes(float value)
        {
            byte[] bytes = BitConverter.GetBytes(value);
            WrieByteArray(bytes);
        }


        private static void WrieByteArray(byte[] bytes)
        {
            foreach (byte b in bytes)
            {
                Console.Write("0x{0:X} ", b);

            }
            Console.WriteLine();
        }

        private static void Arrays()
        {
            float[] grades;
            grades = new float[3];

            AddGrades(grades);

            foreach (float grade in grades)
            {
                Console.WriteLine(grade);
            }

        }

        private static void AddGrades(float[] grades)
        {
            if (grades.Length >= 3)
            {
                grades[0] = 91f;
                grades[1] = 89.1f;
                grades[2] = 75f;
            }            
        }

        private static void Immutable()
        {
            string name = " Scott ";
            name = name.Trim();

            DateTime date = new DateTime(2014, 1, 1);
            date = date.AddHours(25);

            Console.WriteLine(date);
            Console.WriteLine(name);
        }

        private static void PassByValueAndRef()
        {
            GradeBook g1 = new GradeBook();
            GradeBook g2 = g1;

            GiveBookAName(ref g2);
            Console.WriteLine(g2.Name);

            int x1 = 10;
            IncrementNumber(ref x1);
            Console.WriteLine(x1);
        }


        private static void WriteNames(params string[] names)
        {
            foreach (string name in names)
            {
                Console.WriteLine(name);

            }
        }
          
    }
}
