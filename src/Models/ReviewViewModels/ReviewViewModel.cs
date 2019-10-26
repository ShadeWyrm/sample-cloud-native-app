using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GCCloudSample.Models.ReviewViewModel
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public string Comment { get; set; }
        public string UserName { get; set; }
        public string Label { get; set; }
    }
}