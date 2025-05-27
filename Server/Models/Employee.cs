using System;

namespace ResourceSelectionSystem.Models
{
    public class Employee
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
        public string Department { get; set; }
        public string ExperienceLevel { get; set; }
        public int YearsOfExperience { get; set; }

        public int AutoCAD { get; set; }
        public int AutodeskInventor { get; set; }
        public int OpenCascade { get; set; }
        public int ThreeJs { get; set; }
        public int Eyeshot { get; set; }
        public int HOOPS { get; set; }
        public int JavaScript { get; set; }
        public int CSharp { get; set; }
        public int Python { get; set; }
        public int React { get; set; }
        public int NodeJs { get; set; }
        public int AspNet { get; set; }
        public int Unity { get; set; }
        public int UnrealEngine { get; set; }
        public int Revit { get; set; }
        public int Navisworks { get; set; }

        public string CurrentProject { get; set; }
        public string Client { get; set; }
        public string AvailabilityStatus { get; set; }
        public DateTime NextAvailabilityDate { get; set; }
    }
}
