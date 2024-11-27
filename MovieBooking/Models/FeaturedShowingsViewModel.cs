using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieBooking.Models
{
    public class FeaturedShowingsViewModel
    {
        public int feature_id { get; set; }
        public int movie_id { get; set; }
        public string movie_title { get; set; }
        public string movie_image_url { get; set; }
        public DateTime? start_date { get; set; }
        public DateTime? end_date { get; set; }
        public bool is_active { get; set; }

        public List<Movie> MoviesList { get; set; }
    }
}
