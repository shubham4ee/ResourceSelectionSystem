namespace ResourceSelectionSystem.Models
{
    public class MatchResult
    {
        public string EmployeeId { get; set; } // Changed from int to string
        public string Name { get; set; }
        public int MatchScore { get; set; }
    }
}
