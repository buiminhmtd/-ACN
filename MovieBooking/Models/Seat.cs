namespace MovieBooking.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Seat
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Seat()
        {
            Booking_Details = new HashSet<Booking_Details>();
        }

        [Key]
        public int seat_id { get; set; }

        public int? screen_id { get; set; }

        [StringLength(1)]
        public string seat_row { get; set; }

        public int? seat_number { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Booking_Details> Booking_Details { get; set; }

        public virtual Screen Screen { get; set; }
    }
}
