using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void Test1()
        {
            // Arrange Section: Sets test data and objects you are going to use for testing
            var x = GetInt();
            // Act Section: Perform and action such as a calculation
            SetInt(ref x);
            // Assert Section: evaluate the action against the expected output
            Assert.Equal(42, x);
        }

        private void SetInt(ref int z)
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3;
        }

        [Fact]
        public void CSharpCanPassByReference()
        {
            // Arrange Section: Sets test data and objects you are going to use for testing
            var book1 = GetBook("Book 1");
            GetBookSetRefName(ref book1, "New Name");

            // Act Section: Perform and action such as a calculation

            // Assert Section: evaluate the action against the expected output
            Assert.Equal("New Name", book1.Name);
        }

        private void GetBookSetRefName(ref Book book, string name)
        {
            book = new Book(name);
        }
        [Fact]
        public void CSharpIsPassByValue()
        {
            // Arrange Section: Sets test data and objects you are going to use for testing
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            // Act Section: Perform and action such as a calculation

            // Assert Section: evaluate the action against the expected output
            Assert.Equal("Book 1", book1.Name);
        }
        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            // Arrange Section: Sets test data and objects you are going to use for testing
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            // Act Section: Perform and action such as a calculation

            // Assert Section: evaluate the action against the expected output
            Assert.Equal("New Name", book1.Name);
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            // Arrange Section: Sets test data and objects you are going to use for testing
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            // Act Section: Perform and action such as a calculation

            // Assert Section: evaluate the action against the expected output
            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            // Arrange Section: Sets test data and objects you are going to use for testing
            var book1 = GetBook("Book 1");
            var book2 = book1;

            // Act Section: Perform and action such as a calculation

            // Assert Section: evaluate the action against the expected output
            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }

        private void SetName(Book book, string name)
        {
            book.Name = name;
        }
    }
}
