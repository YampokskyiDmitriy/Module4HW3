using System;
using System.Collections.Generic;

namespace Module4HW3.Entities
{
    public class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public DateTime StartedDate { get; set; }
        public ICollection<EmployeeProject> EmployeeProject { get; set; }
    }
}