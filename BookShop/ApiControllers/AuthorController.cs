using BookShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BookShop.ApiControllers
{
    public class AuthorController : ApiController
    {
        public List<author> Get()
        {
            TestDBEntities db = new TestDBEntities();
            List<author> authors = db.authors.ToList();
            return authors;
        }
    }
}
