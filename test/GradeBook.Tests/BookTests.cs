using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void BookCalculatesAnAverageGrade()
        {
            // Arrange Section: Sets test data and objects you are going to use for testing
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            // Act Section: Perform and action such as a calculation
            var results = book.GetStatistics();

            // Assert Section: evaluate the action against the expected output
            Assert.Equal(85.6, results.Average, 1);
            Assert.Equal(90.5, results.High, 1);
            Assert.Equal(77.3, results.Low, 1);
            Assert.Equal('B', results.Letter);
        }
    }
}
