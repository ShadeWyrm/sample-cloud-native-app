using System;
using System.ComponentModel.DataAnnotations;

namespace GCCloudSample.Models
{
    public class Review
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(250)]
        public string Comment { get; set; }
        
        public virtual ApplicationUser User { get; set; }
        
        public virtual DepartmentService DepartmentService { get; set; }
        
        public virtual Rating Rating { get; set;}
    }
}
