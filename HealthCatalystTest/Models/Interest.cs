using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HealthCatalystTest.Models
{
    public class Interest
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string interest { get; set; }
    }
}
