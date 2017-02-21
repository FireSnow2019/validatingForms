using System;
using System.Collections.Generic;
using DapperApp.Factory; //need to include reference to new factory namespace 
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvcnewdojo.Models;

namespace mvcnewdojo.Controllers.Blog
{
    public class BlogController : Controller
    {
        private readonly UserFactory userFactory;
        public BlogController()
        {
            //instantiate a UserFactory obj that is immutable (readonly)
            //This is establish the initial DB Connection for us.

            userFactory = new UserFactory();
        }

        // GET: /Blog/
        [HttpGetAttribute]
        [RouteAttribute("Blog")]
        public IActionResult Blog()
        {
            var test = userFactory.FindAll();
            ViewBag.BlogUser = userFactory.FindAll();
            return View("Index");
        }

    }
}