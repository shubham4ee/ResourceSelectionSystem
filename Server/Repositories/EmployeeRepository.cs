using ResourceSelectionSystem.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace ResourceSelectionSystem.Repositories
{
    public static class EmployeeRepository
    {
        private static List<Employee> _employees = new List<Employee>();

        public static IReadOnlyList<Employee> Employees => _employees.AsReadOnly();

        public static void LoadEmployeesFromCsv(string csvFilePath)
        {
            if (!File.Exists(csvFilePath))
                throw new FileNotFoundException("CSV file not found", csvFilePath);

            var lines = File.ReadAllLines(csvFilePath);

            // Skip header
            _employees = lines.Skip(1)
                .Select(line =>
                {
                    var cols = SplitCsvLine(line);

                    return new Employee
                    {
                        Id = cols[0],
                        Name = cols[1],
                        Role = cols[2],
                        Department = cols[3],
                        ExperienceLevel = cols[4],
                        YearsOfExperience = int.Parse(cols[5]),

                        AutoCAD = int.Parse(cols[6]),
                        AutodeskInventor = int.Parse(cols[7]),
                        OpenCascade = int.Parse(cols[8]),
                        ThreeJs = int.Parse(cols[9]),
                        Eyeshot = int.Parse(cols[10]),
                        HOOPS = int.Parse(cols[11]),
                        JavaScript = int.Parse(cols[12]),
                        CSharp = int.Parse(cols[13]),
                        Python = int.Parse(cols[14]),
                        React = int.Parse(cols[15]),
                        NodeJs = int.Parse(cols[16]),
                        AspNet = int.Parse(cols[17]),
                        Unity = int.Parse(cols[18]),
                        UnrealEngine = int.Parse(cols[19]),
                        Revit = int.Parse(cols[20]),
                        Navisworks = int.Parse(cols[21]),

                        CurrentProject = cols[22],
                        Client = cols[23],
                        AvailabilityStatus = cols[24],
                        NextAvailabilityDate = DateTime.Parse(cols[25], CultureInfo.InvariantCulture)
                    };
                })
                .ToList();
        }

        // CSV splitting to handle commas inside quotes if needed
        private static string[] SplitCsvLine(string line)
        {
            var parts = new List<string>();
            bool inQuotes = false;
            var value = "";

            foreach (var c in line)
            {
                if (c == '"')
                {
                    inQuotes = !inQuotes;
                }
                else if (c == ',' && !inQuotes)
                {
                    parts.Add(value);
                    value = "";
                }
                else
                {
                    value += c;
                }
            }
            parts.Add(value);
            return parts.ToArray();
        }
    }
}
