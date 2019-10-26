using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        
        public ReviewController(GcDbContext context) {
            _dbContext = context;
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
    }
}