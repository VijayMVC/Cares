using System;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Models.DomainModels;

namespace IstMvcFramework.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Employees.Employee), ErrorMessageResourceName = "DepartmentErrorMessage")]
        public int DepartmentId { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Employees.Employee), ErrorMessageResourceName = "NameErrorMessage")]
        public string Name { get; set; }
        public string Bio { get; set; }

        //[DisplayFormat(DataFormatString = "{0:d}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessageResourceType = typeof(Resources.Employees.Employee), ErrorMessageResourceName = "DateErrorMessage")]
        public string DateOfBirth { get; set; }
        public virtual Department Department { get; set; }
        
        public string ImageName { get; set; }
    }
}