using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using GCCloudSample.Models;

namespace GCCloudSample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RatingController : Controller
    {
        private GcDbContext _dbContext;
        
        public RatingController(GcDbContext context) {
            _dbContext = context;
        }
        
        [HttpGet]
        public async Task<List<Rating>> Get() {
            return await _dbContext.Ratings.ToListAsync();
        }
    }
}