using System.Collections.Generic;

namespace Module4HW3.Entities
{
    public class Title
    {
        public int TitleId { get; set; }
        public string Name { get; set; }
        public ICollection<Employee> Employee { get; set; }
    }
}
