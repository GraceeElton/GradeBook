using System.Collections.Generic;
using System;


namespace GradeBook
{
    public class Book
    {



        // constructor 
        public Book(string name)
        {
            grades = new List<double>();
            Name = name;
        }

        // methods 
        public void AddGrade(double grade)
        {
            grades.Add(grade);
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
            return result;
        }


        // feilds 
        private List<double> grades;
        //Public always has an uppercase 
        public string Name;

    }
}