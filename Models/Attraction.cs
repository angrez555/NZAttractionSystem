using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NZAttractionSystem.Models
{
    public class Attraction
    {
        public int Id { get; set; } // Primary Key
        [Required]
        public string Place { get; set; } // Holds the Attration of place
        [Required]
        public string Address { get; set; } // Holds the address of Attration Place 
        [Required]
        public string Description { get; set; } // Description of Place
        [Required]
        public string Open_Hours { get; set; } // place open hours
    }
}
