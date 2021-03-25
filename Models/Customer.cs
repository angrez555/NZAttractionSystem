using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NZAttractionSystem.Models
{
    public class Customer
    {
        public int Id { get; set; } // Primary Key
                                    // [Required]
        public string Name { get; set; } // Holds name of Customer
                                         // [Required]
        public int Mobile { get; set; } // Holds Customers Mobile Number
                                        // [Required]
        public string Email { get; set; } //Holds Customer Email
        //[Required]
        public string Address { get; set; } //Holds the Address of customer
    }
}
