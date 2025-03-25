using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngularProject.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [Column(TypeName = "nvarchar(100)")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [Phone]
        [Column(TypeName = "nvarchar(15)")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(255)")]
        public string Address { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(50)")]
        public string City { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(50)")]
        public string State { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(50)")]
        public string Country { get; set; } = string.Empty;

        [Column(TypeName = "nvarchar(20)")]
        public string PostalCode { get; set; } = string.Empty;
    }
}
