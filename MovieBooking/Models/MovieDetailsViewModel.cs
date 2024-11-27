using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieBooking.Models
{
    public class MovieDetailsViewModel
    {
        public Movie Movie { get; set; }
        public bool HasBookedTicket { get; set; }
        public IEnumerable<Feedback> Feedbacks { get; set; }
    }

}