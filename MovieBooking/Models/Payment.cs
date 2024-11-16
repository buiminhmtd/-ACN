namespace MovieBooking.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Payment
    {
        [Key]
        public int payment_id { get; set; }

        public int? booking_id { get; set; }

        public DateTime? payment_date { get; set; }

        public decimal? amount { get; set; }

        [Required]
        [StringLength(10)]
        public string payment_method { get; set; }

        [StringLength(10)]
        public string status { get; set; }

        public virtual Booking Booking { get; set; }
    }
}
