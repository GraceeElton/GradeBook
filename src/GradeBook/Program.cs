using System;
using System.Collections.Generic;

namespace GradeBook
{

    class Program
    {
        //
        static void Main(string[] args)
        {
            IBook book = new DiskBook("Gracee's BOOK");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"For the book named {book.Name}");
            Console.WriteLine($"The highest grade is {stats.Low} ");
            Console.WriteLine($"The lowest grade is {stats.High} ");
            Console.WriteLine($"The average grade is {stats.Average} ");
            Console.WriteLine($"The average letter grade is {stats.Letter} ");

        }

        private static void EnterGrades(IBook book)
        {
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

                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
    


            }
        }

        static void OnGradeAdded(Object sender, EventArgs a)
        {
            Console.WriteLine("The grade was added to the book.");
        }

    }
}
