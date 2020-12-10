using System.Collections.Generic;
using System;


namespace GradeBook
{
    public delegate void GradeAddedDelegate(object sender, EventArgs args);

    public class Book
    {

        // constructor 
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }
        // methods 
        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                case 'D':
                    AddGrade(60);
                    break;
                case 'F':
                    AddGrade(50);
                    break;

                default:
                    AddGrade(0);
                    break;

            }
        }
        public void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invaild {nameof(grade)} ");
            }

        }


        // use the class name as the name so it is an instance of that class.
        //object of tpye of Statistics.
        public Statistics GetStatistics()
        {
            var result = new Statistics();
            result.Average = 0.0;
            result.High = double.MinValue;
            result.Low = double.MaxValue;

            foreach (var grade in grades)
            {
                result.Low = Math.Min(grade, result.Low);
                result.High = Math.Max(grade, result.High);

                result.Average += grade;


            }
            result.Average /= grades.Count;
            switch (result.Average)
            {
                case var d when d > 90.0:
                    result.Letter = 'A';
                    break;

                case var d when d > 80.0:
                    result.Letter = 'B';
                    break;

                case var d when d > 70.0:
                    result.Letter = 'B';
                    break;

                case var d when d > 60.0:
                    result.Letter = 'D';
                    break;
                default:
                    result.Letter = 'F';
                    break;

            }
            return result;
        }



        public event GradeAddedDelegate GradeAdded;
        // feilds 
        private List<double> grades;
        //Public always has an uppercase name

        public string Name
        {
            // getters and setters formant
            get;
            // you can use PRIVATE so name is read-only 
            set;

        }

        // industry norm is to cap the names of all const vaules
        public const string CATEGORY = "Science";
    }
}