using System;
using System.Collections.Generic;

namespace Module4HW3.Entities
{
    public class Client
    {
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public ICollection<Project> Project { get; set; }
    }
}
