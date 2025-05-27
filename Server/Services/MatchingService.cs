using ResourceSelectionSystem.Models;
using ResourceSelectionSystem.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ResourceSelectionSystem.Services
{
    public class EmployeeService
    {
        private readonly IReadOnlyList<Employee> _employees;

        public EmployeeService()
        {
            _employees = EmployeeRepository.Employees;
        }

        public List<EmployeeMatchResult> MatchEmployees(EmployeeMatchRequest request)
        {
            var results = new List<EmployeeMatchResult>();

            foreach (var emp in _employees)
            {
                // Check availability status match
                if (!string.Equals(emp.AvailabilityStatus, request.Availability, StringComparison.OrdinalIgnoreCase))
                    continue;

                // Check experience level match (simple equals or you can improve)
                if (!string.Equals(emp.ExperienceLevel, request.ExperienceLevel, StringComparison.OrdinalIgnoreCase))
                    continue;

                // Calculate skill score (sum of min of required and employee skill)
                int score = 0;
                foreach (var skill in request.RequiredSkills.Keys)
                {
                    int requiredLevel = request.RequiredSkills[skill];
                    int employeeLevel = GetSkillLevel(emp, skill);
                    score += Math.Min(requiredLevel, employeeLevel);
                }

                if (score > 0)
                {
                    results.Add(new EmployeeMatchResult
                    {
                        Employee = emp,
                        Score = score
                    });
                }
            }

            return results.OrderByDescending(r => r.Score).ToList();
        }

        private int GetSkillLevel(Employee emp, string skillName)
        {
            // Map skill name to Employee property
            return skillName switch
            {
                "AutoCAD" => emp.AutoCAD,
                "AutodeskInventor" => emp.AutodeskInventor,
                "OpenCascade" => emp.OpenCascade,
                "ThreeJs" => emp.ThreeJs,
                "Eyeshot" => emp.Eyeshot,
                "HOOPS" => emp.HOOPS,
                "JavaScript" => emp.JavaScript,
                "CSharp" => emp.CSharp,
                "Python" => emp.Python,
                "React" => emp.React,
                "NodeJs" => emp.NodeJs,
                "AspNet" => emp.AspNet,
                "Unity" => emp.Unity,
                "UnrealEngine" => emp.UnrealEngine,
                "Revit" => emp.Revit,
                "Navisworks" => emp.Navisworks,
                _ => 0
            };
        }
    }

    public class EmployeeMatchRequest
    {
        public Dictionary<string, int> RequiredSkills { get; set; } = new Dictionary<string, int>();
        public string ExperienceLevel { get; set; }
        public string Availability { get; set; }
    }

    public class EmployeeMatchResult
    {
        public Employee Employee { get; set; }
        public int Score { get; set; }
    }
}
