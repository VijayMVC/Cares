using System;
using System.Collections;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Models.RequestModels;
using PagedList;

namespace IstMvcFramework.ViewModels.Employees
{
    public class EmployeeViewModel
    {
        public IPagedList<Models.Employee> EmployeeList { get; set; }
        public IEnumerable Departments { get; set; }
        public int? TotalNoOfRec { get; set; }
        public string DateOfBirth { get; set; }
        public EmployeeSearchRequest EmployeeSearchRequest { get; set; }
        public Models.Employee Employee { get; set; }
        [Required(ErrorMessage = "You must provide Image")]
        public HttpPostedFileBase UploadImage { get; set; }
    }
}