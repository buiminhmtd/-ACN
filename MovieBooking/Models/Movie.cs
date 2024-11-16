namespace MovieBooking.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Movie
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Movie()
        {
            Featured_Showings = new HashSet<Featured_Showings>();
            Feedbacks = new HashSet<Feedback>();
            Showtimes = new HashSet<Showtime>();
        }

        [Key]
        public int movie_id { get; set; }

        [Required]
        [StringLength(255)]
        public string title { get; set; }

        public string description { get; set; }

        public int? duration { get; set; }

        [StringLength(50)]
        public string genre { get; set; }

        [Column(TypeName = "date")]
        public DateTime? release_date { get; set; }

        [Required]
        [StringLength(500)]
        public string image_url { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Featured_Showings> Featured_Showings { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Feedback> Feedbacks { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Showtime> Showtimes { get; set; }
    }
}
