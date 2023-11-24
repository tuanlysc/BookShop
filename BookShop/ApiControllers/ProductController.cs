using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookShop.ApiControllers
{
    public class ProductController : ApiController
    {
        public List<book> Get()
        {
            TestDBEntities db = new TestDBEntities();
            List<book> books = db.books.ToList();
            return books;
        }
    }
}
