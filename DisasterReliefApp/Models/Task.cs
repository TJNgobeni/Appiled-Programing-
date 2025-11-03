namespace DisasterReliefApp.Models
{
    public class Task
    {
        public int TaskId { get; set; }
        public string? TaskName { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? RequiredSkills { get; set; }
        public string? Status { get; set; }
    }
}