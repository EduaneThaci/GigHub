﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GigHub.Models;
using GigHub.ViewModels;

namespace GigHub.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public HomeController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var upcomingGigs = _context.Gigs
                .Include("Artist")
                .Include("Genre")
                .Where(g => g.DateTime > DateTime.Now);

            var viewModel = new GigViewModel
            {
                UpcomingGigs = upcomingGigs,
                ShowActions = User.Identity.IsAuthenticated
            };

            return View(upcomingGigs);
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
    }
}