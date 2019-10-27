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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
