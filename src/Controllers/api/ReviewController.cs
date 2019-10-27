using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using GCCloudSample.Models;
using GCCloudSample.Models.ReviewViewModel;

namespace GCCloudSample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReviewController : Controller
    {
        private GcDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        
        public ReviewController(UserManager<ApplicationUser> userManager, GcDbContext context) {
            _dbContext = context;
            _userManager = userManager;
        }
        
        [HttpGet]
        public async Task<List<ReviewViewModel>> Get() {
            return await _dbContext.Reviews.Include(x => x.Rating).Include(x => x.DepartmentService).Include(x => x.User).Select(
                x => new ReviewViewModel {
                    Id = x.Id,
                    Comment = x.Comment,
                    UserName = x.User.UserName,
                    Label = x.Rating.EnglishLabel
                }).ToListAsync();
        }
        
        [HttpGet("{id}")]
        public async Task<List<ReviewViewModel>> Get(int id) {
            return await _dbContext.Reviews.Include(x => x.Rating).Include(x => x.DepartmentService).Include(x => x.User).Where(x => x.DepartmentService.Id == id).Select(
                x => new ReviewViewModel {
                    Id = x.Id,
                    Comment = x.Comment,
                    UserName = x.User.UserName,
                    Label = x.Rating.EnglishLabel
                }).ToListAsync();
        }
        
        [HttpPut, Authorize]
        public IActionResult Put(SubmitReviewModel model) {
            
            int serviceId = model.ServiceId;
            int ratingId = model.RatingId;
            
            string userId = _userManager.GetUserId(User);

            var serviceObject = _dbContext.DepartmentServices.FirstOrDefault(x => x.Id == serviceId);
            var rating = _dbContext.Ratings.FirstOrDefault(x => x.Id == ratingId);
            var userData = _dbContext.Users.FirstOrDefault(x => x.Id == userId);
            
            
            Review userReview = new Review {
                User = userData,
                DepartmentService = serviceObject,
                Rating = rating,
                Comment = model.Comment
            };
            _dbContext.Add(userReview);
            _dbContext.SaveChanges();
            
            return Ok(userReview);
        }
    }
}