using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HowdyFresh.Models
{
    public class Restaurant
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cuisine { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string ContactEmail { get; set; }
        public string PhoneNumber { get; set; }
        public int Rating { get; set; }

        [ForeignKey("IdentityUser")]
        public string IdentityUserId { get; set; }
        public IdentityUser IdentityUser { get; set; }

    }
}
