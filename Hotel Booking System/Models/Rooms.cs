using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Booking_System.Models
{
    public class Rooms
    {
        

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int RoomId { get; set; }

        [ForeignKey(nameof(Hotels))]
        public int HotelId { get; set; }

        [Required]
        public int RoomNumber { get; set; }

        [Required]
        public string? AvalabilityStatus { get; set; }

        public ICollection<HotelBooking>? hotelBookings { get; set; }
    }
}
