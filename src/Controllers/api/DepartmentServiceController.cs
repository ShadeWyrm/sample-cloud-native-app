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

            List<DepartmentService> services = await _dbContext.DepartmentServices.ToListAsync();
            if (services.Count() == 0) {
                DepartmentService ds1 = new DepartmentService() { Id = 0, EnglishLabel = "Cat Petting Service", FrenchLabel = "Cat Petting Service - FR" };
                DepartmentService ds2 = new DepartmentService() { Id = 1, EnglishLabel = "Dog Sitting Service", FrenchLabel = "Dog Sitting Serbvice - FR"};

                _dbContext.Add(ds1);
                _dbContext.Add(ds2);
                _dbContext.SaveChanges();

                services.Add(ds1);
                services.Add(ds2);
            }

            return services;
        }
    }
}