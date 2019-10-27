using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GCCloudSample.Models.ReviewViewModel
{
    public class SubmitReviewModel
    {
        public int ServiceId { get; set; }
        public string Comment { get; set; }
        public int RatingId { get; set; }
    }
}