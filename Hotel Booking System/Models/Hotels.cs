using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Booking_System.Models
{
    public class Hotels
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int HotelId { get; set; }

        [Required]
        public string? HotelName { get; set; }

        [Required]
        public int TotalRooms  { get; set; }

        [Required]
        public float price { get; set; }

        [Required]
        public string? Location { get; set; }


        public ICollection<Rooms>? Rooms { get; set; }

        public ICollection<HotelBooking>? hotelBookings { get; set; }

    
    }

}
