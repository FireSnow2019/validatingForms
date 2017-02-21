using System;
using System.Collections.Generic;
using DapperApp.Factory; //need to include reference to new factory namespace 
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using mvcnewdojo.Models;

namespace mvcnewdojo.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserFactory userFactory;
        public HomeController()
        {
            //instantiate a UserFactory obj that is immutable (readonly)
            //This is establish the initial DB Connection for us.

            userFactory = new UserFactory();
        }
        
        // GET: /Home/
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            ViewBag.errors = "";
            return View();
        }

        [HttpPostAttribute ("")]
        public IActionResult Index(User UserInfo)
        {
            //TryValidateModel(UserInfo);
            
            if(ModelState.IsValid && verifyPassword(UserInfo.password1, UserInfo.password2))
            {
                System.Console.WriteLine("Made it here!");
                TempData["FirstName"] = UserInfo.firstname;
                TempData["LastName"] = UserInfo.lastname;
                TempData["Age"] = UserInfo.age;
                TempData["Email"] = UserInfo.email;
                TempData["Password1"] = UserInfo.password1;
                TempData["Password2"] = UserInfo.password2;


                return RedirectToAction("Success");
            }
            ViewBag.errors = ModelState.Values;
            System.Console.WriteLine("//// ERROR - Model State is false \\\\");
            return View();

        }   

        [HttpGetAttribute ("success")]
        public IActionResult Success()
        {
            ViewBag.FirstName = TempData["FirstName"];
            ViewBag.LastName = TempData["LastName"];
            ViewBag.Age = TempData["Age"];
            ViewBag.Email = TempData["Email"];
            ViewBag.Password1 = TempData["Password1"];
            ViewBag.Password2 = TempData["Password2"];

            return View();
        }  

        public bool verifyPassword(string pwd1, string pwd2)  
        {
            if(pwd1 == pwd2)
            {
                return true;
            }
            return false;
        } 
    }
}
