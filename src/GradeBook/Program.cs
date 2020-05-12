using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please Enter the name of your grade book.");
            var inputName = Console.ReadLine();

            IBook book = new DiskBook(inputName);
            book.GradeAdded += OnGradeAdded;

            GradeEntry(book);

            var stats = book.GetStatistics();

            Console.WriteLine($"For the GradeBook named {book.Name}");
            Console.WriteLine($"The average grade is {stats.Average:N1}");
            Console.WriteLine($"The highest grade is {stats.High:N1}");
            Console.WriteLine($"The lowest grade is {stats.Low:N1}");
            Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        static void GradeEntry(IBook book)
        {
            var check = true;

            while (check == true)
            {
                Console.WriteLine("Please Enter a Numerical grade value or press 'q' to exit");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    check = false;
                    continue;
                }

                try
                {
                    var num = double.Parse(input);
                    book.AddGrade(num);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**********");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("Grade has been added");
        }

    }
}
