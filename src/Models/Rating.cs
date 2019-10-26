using System;
using System.ComponentModel.DataAnnotations;

namespace GCCloudSample.Models
{
    public class Rating
    {
        [Key]
        public int Id { get; set; }
        
        public string EnglishLabel {get; set;}
        public string FrenchLabel {get; set;}
    }
}
