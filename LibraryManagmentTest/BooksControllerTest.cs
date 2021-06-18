using LibraryManagement.Controllers;
using LibraryManagement.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LibraryManagmentTest
{
    public class BooksControllerTest
    {

        //var context = new LibraryWebContext();
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public async Task GetBooks_shouldReturnAllBooks()
        {
            //Arrange: In memory database
            var options = new DbContextOptionsBuilder<LibraryWebContext>()
                .UseInMemoryDatabase(databaseName: "LibraryDataBase")
                .Options;
            int booksRecordCount = 2;

            //Mock data for Books and Auther entity
            using (var context = new LibraryWebContext(options))
            {

                context.Authors.Add(new Author
                {
                    AuthorId = 1,
                    FirstName = "Kelly",
                    LastName = "Zom"

                });
                context.SaveChanges();


                context.Books.Add(new Book
                {
                    BookId = 1,
                    Title  = "New Journy of Life",
                    AuthorId = 1,
                    Author = new Author()
                });

                context.Books.Add(new Book
                {
                    BookId = 2,
                    Title = "Future of IT",
                    AuthorId = 1,
                    Author = new Author()
                });
                context.SaveChanges();



                BooksController controller = new BooksController(context);
                var result = await controller.GetBooks() as ActionResult<IEnumerable<Book>>;
                var actualResult = result.Value;

                Assert.IsTrue(((System.Collections.Generic.List<LibraryManagement.Model.Book>)actualResult).Count == booksRecordCount);
            }
        }

        [Test]
        public async Task GetBooksById_shouldReturnBook()
        {
            //Arrange: In memory database
            var options = new DbContextOptionsBuilder<LibraryWebContext>()
                .UseInMemoryDatabase(databaseName: "LibraryDataBase")
                .Options;

            //Mock data for Books and Auther entity
            using (var context = new LibraryWebContext(options))
            {

                context.Authors.Add(new Author
                {
                    AuthorId = 1,
                    FirstName = "Kelly",
                    LastName = "Zom"

                });
                context.SaveChanges();


                context.Books.Add(new Book
                {
                    BookId = 1,
                    Title = "New Journy of Life",
                    AuthorId = 1,
                    Author = new Author()
                });

                context.Books.Add(new Book
                {
                    BookId = 2,
                    Title = "Future of IT",
                    AuthorId = 1,
                    Author = new Author()
                });
                context.SaveChanges();



                BooksController controller = new BooksController(context);
                var result = (ActionResult<Book>) await controller.GetBook(1);
                var actualResult = result.Value;

                Assert.IsTrue(actualResult != null);
                Assert.IsTrue(actualResult.BookId == 1);
                Assert.IsTrue(actualResult.Title.Equals("New Journy of Life"));
            }
        }
    }
}