using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {   
            Console.WriteLine("Please Enter the name of your grade book.");
            var inputName = Console.ReadLine();

            var book = new Book(inputName);
            book.GradeAdded += OnGradeAdded;
            
            book.GradeEntry();

            var stats = book.GetStatistics();

            Console.WriteLine(Book.CATEGORY);
            Console.WriteLine($"For the GradeBook named {book.Name}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The highest grade is {stats.High:N1}");
            Console.WriteLine($"The lowest grade is {stats.Low:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }
        
        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("Grade has been added");
        }

    }
}
