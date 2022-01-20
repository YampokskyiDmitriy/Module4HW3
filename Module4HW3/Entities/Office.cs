﻿using System.Collections.Generic;

namespace Module4HW3.Entities
{
    public class Office
    {
        public int OfficeId { get; set; }
        public string Title { get; set; }
        public string Location { get; set; }
        public ICollection<Employee> Employee { get; set; }
    }
}