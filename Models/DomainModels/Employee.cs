using System;

namespace Models.DomainModels
{
    /// <summary>
    /// Employee Domain Model
    /// </summary>
    public class Employee
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public string Name { get; set; }
        public string Bio { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Image { get; set; }
        public virtual Department Department { get; set; }
    }
}
