using System;
using Xunit;
using static PhilsLendingLibrary.Program;
using PhilsLendingLibrary.Classes;
using System.Collections.Generic;

namespace PhilsLendingLibraryTest
{
    public class UnitTest1
    {
        [Fact]
        public void AddABookToYourLibraryThatExists()
        {
            AddABook("Test Book", "Kyungrae", "Kim", 999, PhilsLendingLibrary.Genre.Fiction);
            Book testBook = null;
            foreach (var item in Library)
            {
                testBook = item;
            }
            Assert.Equal("Test Book", testBook.Title);
        }

        [Fact]
        public void RemoveABookFromYourLibrary()
        {
            AddABook("Test Book", "Kyungrae", "Kim", 999, PhilsLendingLibrary.Genre.Fiction);
            Book testBook = null;
            foreach (var item in Library)
            {
                testBook = item;
            }
            Library.Remove(testBook);
            Assert.Equal(0, Library.Count());
        }

       
        [Fact]
        public void GetterSettersOfYourPropertiesFromBookClass()
        {
            Book testBook = new Book();
            testBook.Title = "Test Book";
            testBook.Author = new Author
            {
                FirstName = "Kyungrae",
                LastName = "Kim"
            };
            testBook.NumberOfPages = 999;
            testBook.Genre = PhilsLendingLibrary.Genre.Fiction;

            Assert.Equal("Test Book (999) Fiction - Kyungrae Kim", $"{testBook.Title} ({testBook.NumberOfPages}) {testBook.Genre} - {testBook.Author.FirstName} {testBook.Author.LastName}");
        }

        [Fact]
        public void GetterSettersOfYourPropertiesFromAuthoClass()
        {
            Book testBook = new Book();
            testBook.Title = "Test Book";
            testBook.Author = new Author
            {
                FirstName = "Kyungrae",
                LastName = "Kim"
            };
            testBook.NumberOfPages = 999;
            testBook.Genre = PhilsLendingLibrary.Genre.Fiction;

            Assert.Equal("Kyungrae Kim", $"{testBook.Author.FirstName} {testBook.Author.LastName}");
        }

        [Fact]
        public void AccuruateCountOfBooksWithinTheLibrary()
        {
            Assert.Equal(0, Library.Count());
        }

        [Fact]
        public void EdgeCase()
        {
            Book testBook = new Book();
            testBook.Title = "Test Book";
            testBook.Author = new Author
            {
                FirstName = "Kyungrae",
                LastName = "Kim"
            };
            testBook.NumberOfPages = 999;
            testBook.Genre = PhilsLendingLibrary.Genre.Fiction;

            Assert.NotEqual(2, Library.Count());
        }
    }
}