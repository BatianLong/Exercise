using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApi.Controllers
{
    public class BookController : ApiController
    {
        [Route("api/GetMyAllBook")]
        public IHttpActionResult GetBook()
        {
            List<Book> bookList = new List<Book>();
            bookList.Add(new Book() { BookId = 12, BookName = "WebApi入门" });
            bookList.Add(new Book() { BookId = 12, BookName = "WebApi入门1" });
            return Ok(bookList);
        }
        public class Book
        {
            public int BookId { get; set; }

            public String BookName { get; set; }
        }
    }
}
