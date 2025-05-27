namespace ResourceSelectionSystem.Models
{
    public class MatchRequest
    {
        public Dictionary<string, int> RequiredSkills { get; set; } = new();
        public string ExperienceLevel { get; set; }
        public string Availability { get; set; }
    }
}
