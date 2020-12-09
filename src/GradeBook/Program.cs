using System;
using System.Collections.Generic;

namespace GradeBook
{

    class Program
    {
        //
        static void Main(string[] args)
        {
            var book = new Book("Gracee's Gradebook");

            while (true)
            {
                Console.WriteLine("Enter a grade or 'q' to quit.");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }
                //use this to catch or handle execpetions 
                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }


            }

            var stats = book.GetStatistics();

            Console.WriteLine($"The highest grade is {stats.Low} ");
            Console.WriteLine($"The lowest grade is {stats.High} ");
            Console.WriteLine($"The average grade is {stats.Average} ");
            Console.WriteLine($"The average letter grade is {stats.Letter} ");




        }

    }
}
