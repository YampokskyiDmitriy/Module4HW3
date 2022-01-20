using System;
using System.Collections.Generic;

namespace Module4HW3.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public DateTime HiredDate { get; set; }
        public DateTime? DateOfBirth { get; set; }

        public int OfficeId { get; set; }
        public Office Office { get; set; }

        public int TitleId { get; set; }
        public Title Title { get; set; }

        public ICollection<EmployeeProject> EmployeeProject { get; set; }
    }
}
