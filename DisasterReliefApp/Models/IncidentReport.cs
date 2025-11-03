using System;
using System.ComponentModel.DataAnnotations;

namespace DisasterReliefApp.Models
{
    public class IncidentReport
    {
        [Key]
        public int Id { get; set; }
        public string ReportedBy { get; set; }
        public string IncidentType { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime DateOccurred { get; set; }
        public int Severity { get; set; }
        public string AffectedAreas { get; set; }
        public string ResourcesNeeded { get; set; }
        public int Injuries { get; set; }
        public int Fatalities { get; set; }

        public DateTime ReportDate { get; set; } = DateTime.Now;
    }
}
