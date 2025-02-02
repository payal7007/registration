﻿using OlxDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OlxDemo.Controllers
{
    public class HomeController : Controller
    {


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult Registration()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Registration(RegistrationModel model)
        {
            RegistrationRepo repo = new RegistrationRepo();

            var isemailalreadyexists = repo.IsEmailAlreadyExists(model.@userEmail);

            if (isemailalreadyexists)
            {
                ModelState.AddModelError("useremail", "this email already exists.");

            }
            else
            {
                bool registrationResult = repo.InsertUser(model);

                if (registrationResult)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Registration failed. Please try again.");
                    return View(model);
                }

            }
            return View(model);

        }
        }

    }

