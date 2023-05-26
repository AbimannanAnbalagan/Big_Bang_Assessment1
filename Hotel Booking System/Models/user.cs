using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel_Booking_System.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Enter Username")]
        public string? UserName { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        public string? UserEmail { get; set; }

        [Required(ErrorMessage = "Enter Password")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Enter ")]
        public string? Roles { get; set; }

        public ICollection<HotelBooking>? HotelBookings { get; set; }
    }
}
