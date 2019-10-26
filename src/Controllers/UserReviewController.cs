using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using System.Text.Json;
using System.Text.Json.Serialization;
using GCCloudSample.Models;

namespace GCCloudSample.Controllers
{
    [Authorize]
    public class UserReviewController : Controller
    {
        private readonly ILogger<UserReviewController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private GcDbContext _dbContext;

        public UserReviewController(UserManager<ApplicationUser> userManager, ILogger<UserReviewController> logger, GcDbContext context)
        {
            _logger = logger;
            _userManager = userManager;
            _dbContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult Service(int Id) {
            ViewData["id"] = Id;
            return View();
        }
        
        public IActionResult Read(int Id, int reviewId) {
            ViewData["id"] = Id;
            ViewData["reviewId"] = reviewId;
            return View();
        }
        
        public IActionResult Add(int Id) {
            ViewData["id"] = Id;
            return View();
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(IFormCollection form) {
            
            int serviceId = 0;
            Int32.TryParse(form["Id"][0], out serviceId);
            int ratingId = 0;
            Int32.TryParse(form["ReviewType"][0], out ratingId);
            
            string comment = form["Comment"][0];

            var serviceObject = _dbContext.DepartmentServices.FirstOrDefault(x => x.Id == serviceId);
            var rating = _dbContext.Ratings.FirstOrDefault(x => x.Id == ratingId);
            var userData = _dbContext.Users.FirstOrDefault(x => x.Id == _userManager.GetUserId(User));
            
            Review userReview = new Review {
                User = userData,
                DepartmentService = serviceObject,
                Rating = rating,
                Comment = comment
            };
            
            _dbContext.Add(userReview);
            _dbContext.SaveChanges();

            return RedirectToAction("Service", "UserReview", new { Id = serviceId });
        
            //return Ok(userReview);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
