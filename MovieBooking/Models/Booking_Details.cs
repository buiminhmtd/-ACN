namespace MovieBooking.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Booking_Details
    {
        [Key]
        public int booking_detail_id { get; set; }

        public int? booking_id { get; set; }

        public int? seat_id { get; set; }

        public decimal? price { get; set; }

        public virtual Booking Booking { get; set; }

        public virtual Seat Seat { get; set; }
    }
}
