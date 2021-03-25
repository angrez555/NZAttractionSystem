using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NZAttractionSystem.Models
{
    public class Booking
    {
        public int Id { get; set; } //Primary Key
        [Required]
        public int Number_of_Tickets { get; set; } //No. Of tickets to buy
        [Required]
        public int Ticket_Price { get; set; } //Price of Ticket
 
        //Adding the Foriegn Key by linking to Customer Class
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        //Adding the Foriegn Key by linking to Attraction Class
        public int AttractionId { get; set; }
        public Attraction Attraction { get; set; }

    }
}
