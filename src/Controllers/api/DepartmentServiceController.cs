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
    public class DepartmentServiceController : Controller
    {
        private GcDbContext _dbContext;
        
        public DepartmentServiceController(GcDbContext context) {
            _dbContext = context;
        }
        
        [HttpGet]
        public async Task<List<DepartmentService>> Get() {
            return await _dbContext.DepartmentServices.ToListAsync();
        }
    }
}