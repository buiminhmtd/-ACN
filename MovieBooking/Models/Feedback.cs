namespace MovieBooking.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Feedback")]
    public partial class Feedback
    {
        [Key]
        public int feedback_id { get; set; }

        public int? user_id { get; set; }

        public int? movie_id { get; set; }

        public int? showtime_id { get; set; }

        [StringLength(1000)]
        public string comments { get; set; }

        public DateTime? feedback_date { get; set; }

        public virtual Movie Movy { get; set; }

        public virtual Showtime Showtime { get; set; }

        public virtual User User { get; set; }
    }
}
