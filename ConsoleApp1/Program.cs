using System;
using System.Collections.Generic;
using PhilsLendingLibrary.Classes;

namespace PhilsLendingLibrary
{
    public enum Genre
    {
        Fiction = 1,
        NonFiction,
        Poetry,
        Biography,
        Romance
    }

    public class Program
    {
        public static Library<Book> Library = new Library<Book>();
        public static Classes.List<Book> BookBag = new Classes.List<Book>();

        static void Main(string[] args)
        {
            LoadBooks();

            bool displayMenu = true;
            while (displayMenu)
            {
                displayMenu = UserInterface();
            }
        }

        public static bool UserInterface()
        {
            Console.Clear();
            Console.WriteLine("1. View all books");
            Console.WriteLine("2. Add a book");
            Console.WriteLine("3. Borrow a book");
            Console.WriteLine("4. Return a book");
            Console.WriteLine("5. View Book Bag");
            Console.WriteLine("6. Exit");
            Console.Write("Choose an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();

                    ViewBooks();
                    Console.WriteLine("");
                    Console.Write("Press 'Enter' to continue");
                    Console.ReadLine();
                    return true;
                case "2":
                    Console.Clear();

                    Console.Write("Title: ");
                    string titleAdd = Console.ReadLine();
                    Console.Write("First Name of the author: ");
                    string firstName = Console.ReadLine();
                    Console.Write("Last Name of the auhor: ");
                    string lastName = Console.ReadLine();
                    Console.Write("Number of Pages: ");
                    string numberOfPages = Console.ReadLine();
                    Console.WriteLine("1. Fiction");
                    Console.WriteLine("2. Non-Fiction");
                    Console.WriteLine("3. Poetry:");
                    Console.WriteLine("4. Biography");
                    Console.WriteLine("5. Romance");
                    string genre = Console.ReadLine();

                    AddABook(titleAdd, firstName, lastName, Convert.ToInt32(numberOfPages), (Genre)Convert.ToInt32(genre));
                    Console.WriteLine("");
                    Console.WriteLine("Book was added to the library");
                    Console.Write("Press 'Enter' to continue");
                    Console.ReadLine();
                    return true;
                case "3":
                    Console.Clear();

                    BorrowBook();
                    Console.WriteLine("");
                    Console.WriteLine("Book was added to Book Bag");
                    Console.Write("Press 'Enter' to continue");
                    Console.ReadLine();
                    return true;
                case "4":
                    Console.Clear();

                    ReturnBook();
                    Console.WriteLine("");
                    Console.WriteLine("Book was returned to the library");
                    Console.Write("Press 'Enter' to continue");
                    Console.ReadLine();
                    return true;
                case "5":
                    Console.Clear();

                    ViewBookBag();
                    Console.WriteLine("");
                    Console.Write("Press 'Enter' to continue");
                    Console.ReadLine();
                    return true;
                case "6":
                    return false;
                default:
                    Console.WriteLine("That was an invalid entry.");
                    return true;
            }
        }

        public static void ViewBooks()
        {
            int counter = 1;
            foreach (var item in Library)
            {
                Console.WriteLine($"{counter++}. {item.Title} - {item.Author.FirstName} {item.Author.LastName}");
            }
        }

        public static void LoadBooks()
        {
            AddABook("To Kill a Mockingbird", "Harper", "Lee", 296, Genre.Fiction);
            AddABook("The Diary of a Young Girl", "Anne", "Frank", 283, Genre.NonFiction);
            AddABook("Steve Jobs", "Walter", "Isaacson", 656, Genre.Biography);
            AddABook("Odyssey", "Hormer", "", 448, Genre.Poetry);
            AddABook("Pride and Prejudice", "Jane", "Austen", 401, Genre.Romance);
        }

        public static void AddABook(string title, string firstName, string lastName, int numberOfPages, Genre genre)
        {
            Book book = new Book()
            {
                Title = title,
                Author = new Author()
                {
                    FirstName = firstName,
                    LastName = lastName
                },
                NumberOfPages = numberOfPages,
                Genre = genre
            };
            Library.Add(book);
        }

        public static void BorrowBook()
        {
            Dictionary<int, Book> books = new Dictionary<int, Book>();
            Console.WriteLine("Which book would you like to borrow");
            int counter = 1;
            foreach (var item in Library)
            {
                books.Add(counter, item);
                Console.WriteLine($"{counter++}. {item.Title} - {item.Author.FirstName} {item.Author.LastName}");

            }
            Console.WriteLine("");
            string response = Console.ReadLine();
            int.TryParse(response, out int selection);
            books.TryGetValue(selection, out Book borrowedBook);
            Library.Remove(borrowedBook);
            BookBag.Add(borrowedBook);
        }

        static void ReturnBook()
        {
            Dictionary<int, Book> books = new Dictionary<int, Book>();
            Console.WriteLine("Which book would you like to return");
            int counter = 1;
            foreach (var item in BookBag)
            {
                books.Add(counter, item);
                Console.WriteLine($"{counter++}. {item.Title} - {item.Author.FirstName} {item.Author.LastName}");

            }
            Console.WriteLine("");
            string response = Console.ReadLine();
            int.TryParse(response, out int selection);
            books.TryGetValue(selection, out Book returnedBook);
            BookBag.Remove(returnedBook);
            Library.Add(returnedBook);
        }

        public static void ViewBookBag()
        {
            int counter = 1;
            foreach (var item in BookBag)
            {
                Console.WriteLine($"{counter++}. {item.Title} - {item.Author.FirstName} {item.Author.LastName}");
            }
        }
    }
}