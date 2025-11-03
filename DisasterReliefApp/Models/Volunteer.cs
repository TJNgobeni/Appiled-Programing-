using System.ComponentModel.DataAnnotations;

namespace DisasterReliefApp.Models
{
    public class Volunteer
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Skills { get; set; } = string.Empty;
        public string Availability { get; set; } = string.Empty;
    }
}
