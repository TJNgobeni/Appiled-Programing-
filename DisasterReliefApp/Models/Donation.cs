using System;
using System.ComponentModel.DataAnnotations;

namespace DisasterReliefApp.Models
{
    public class Donation
    {
        public int DonationId { get; set; } // Primary key

        [Required(ErrorMessage = "Name is required")]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters")]
        public string Name { get; set; } = null!; // non-nullable, initialized

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = null!;

        [Phone(ErrorMessage = "Invalid phone number")]
        public string? Phone { get; set; } 

        [Required(ErrorMessage = "Resource Type is required")]
        [Display(Name = "Resource Type")]
        public string ResourceType { get; set; } = null!;  // e.g., Food, Clothes, Money

        [StringLength(200, ErrorMessage = "Condition cannot exceed 200 characters")]
        public string? Condition { get; set; } 

        [DataType(DataType.Date)]
        [Display(Name = "Expiration Date")]
        public DateTime? ExpirationDate { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be greater than 0")]
        public int Quantity { get; set; }

        [Display(Name = "Donation Date")]
        public DateTime DonationDate { get; set; } = DateTime.Now;

        [StringLength(500, ErrorMessage = "Notes cannot exceed 500 characters")]
        public string? Notes { get; set; } 

        [StringLength(50, ErrorMessage = "Status cannot exceed 50 characters")]
        public string? Status { get; set; } // optional
    }
}
