using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AdventurePlanner.Models;
using Adventure.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Adventure.Repository.Repositories;
using Adventure.Repository.Models;
using Microsoft.AspNetCore.Http;

namespace AdventurePlanner.Controllers
{
    public class HomeController : Controller
    {

        private IUserAdventureRepository _userAdventureRepository;
        private IUserRepository _userRepository;

        public HomeController(IUserAdventureRepository userAdventureRepository, IUserRepository userRepository)
        {
            _userAdventureRepository = userAdventureRepository;
            _userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();

        }

        //Login
        [HttpPost]
        public IActionResult Login(User user)
        {
            User userApproved = _userRepository.GetOne(user);
            if (userApproved != null)
            {
                HttpContext.Session.SetString("UserId", userApproved.UserId.ToString());
                HttpContext.Session.SetString("Email", userApproved.Email);
                return View("UserAdventure");

            }
            else
            {
                return View("Start");
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                _userRepository.Create(user);
                ViewBag.Message = user.Name + " has been registrated successfully.";
            }
            return View("Start");
            //TODO: Figure out what to do with Questions
        }

        public IActionResult Start()
        {
            return View("Start");
        }

        public IActionResult Tea()
        {
            return View("Tea");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
