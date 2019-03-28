using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace HealthCatalystTest.Models
{
    public class PeopleInterestRelation
    {
        [Key]
        public int Id { get; set; }

        public int PeopleID { get; set; }
       
        public int InterestID { get; set; }
    }
}
