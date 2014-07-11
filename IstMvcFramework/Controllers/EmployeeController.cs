using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Interfaces.IServices;
using IstMvcFramework.ExceptionUtilities;
using IstMvcFramework.ModelMappers;
using IstMvcFramework.ViewModels.Common;
using IstMvcFramework.ViewModels.Employees;
using Models.RequestModels;
using Models.ResponseModels;
using PagedList;

namespace IstMvcFramework.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService employeeService;
        private readonly IDepartmentService departmentService;

        public EmployeeController(IEmployeeService empService, IDepartmentService depService)
        {
            employeeService = empService;
            departmentService = depService;
        }

        public EmployeeController()
        {

        }
        //
        // GET: /Employee/
        public ActionResult Index(EmployeeSearchRequest requestModel)
        {
            ViewBag.MessageVM = TempData["message"] as MessageViewModel;
            EmployeeViewModel employeeViewModel = GetData(requestModel);
            if (Request.IsAjaxRequest())
            {
                return PartialView("_Product", employeeViewModel);
            }

            return View(employeeViewModel);
        }

        private EmployeeViewModel GetData(EmployeeSearchRequest request)
        {
            EmployeeResponse employees = employeeService.LoadAll(request);
            IEnumerable<Models.Employee> enumerableEmployee = employees.Employees.Select(x => x.CreateFrom()).ToList();
            var employeeViewModel = new EmployeeViewModel
            {
                EmployeeList = new StaticPagedList<Models.Employee>(enumerableEmployee, request.PageNo, request.PageSize, employees.TotalCount),
                Departments = departmentService.LoadAll().AsEnumerable(),
                DateOfBirth = enumerableEmployee.Select(x=>x.DateOfBirth).First().ToString(),
                TotalNoOfRec = employees.TotalCount,
                EmployeeSearchRequest = request
            };
            return employeeViewModel;
        }
        //
        // GET: /Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Employee/Create
        public ActionResult Create(int? id)
        {
            // ReSharper disable once SuggestUseVarKeywordEvident
            EmployeeViewModel viewModel = new EmployeeViewModel();
            if (id != null)
            {
                viewModel.Employee = employeeService.Find((int)id).CreateFrom();
            }
            viewModel.Departments = departmentService.LoadAll().AsEnumerable();
            return View(viewModel);
        }

        //
        // POST: /Employee/Create
        [HttpPost]
        [CustomExceptionFilter]
        [ValidateInput(false)]
        public ActionResult Create(EmployeeViewModel viewModel)
        {
            // ReSharper disable once SuggestUseVarKeywordEvident
            MessageViewModel messageViewModel = new MessageViewModel();

            //Save image to file
            var filename = viewModel.UploadImage.FileName;
            var filePathOriginal = Server.MapPath("/App_Data/ProfileImages");
            string savedFileName = Path.Combine(filePathOriginal, filename);

            viewModel.Employee.ImageName = filename;

            //update product
            if (viewModel.Employee.Id > 0)
            {
                if (employeeService.Update(viewModel.Employee.CreateFrom()))
                {
                    viewModel.UploadImage.SaveAs(savedFileName);
                    messageViewModel.IsUpdated = true;
                    SetEditMessage(messageViewModel);
                    return RedirectToAction("Index");
                }
            }
            // add new product
            else
            {
                if (employeeService.Add(viewModel.Employee.CreateFrom()))
                {
                    viewModel.UploadImage.SaveAs(savedFileName);

                    messageViewModel.IsSaved = true;
                    SetSaveMessage(messageViewModel);
                    return RedirectToAction("Index");
                }
            }

            viewModel = SetErrorMessage(viewModel);
            return View(viewModel);

        }
        private EmployeeViewModel SetErrorMessage(EmployeeViewModel viewModel)
        {
            // ReSharper disable once SuggestUseVarKeywordEvident
            MessageViewModel messageViewModel = new MessageViewModel
            {
                IsError = true,
                Message = Resources.Products.Product.DuplicateName
            };
            ViewBag.MessageVM = messageViewModel;
            viewModel.Departments = departmentService.LoadAll().AsEnumerable();
            return viewModel;
        }
        private void SetEditMessage(MessageViewModel messageViewModel)
        {
            messageViewModel.Message = Resources.Products.Product.Edit;
            TempData["message"] = messageViewModel;
        }

        private void SetSaveMessage(MessageViewModel messageViewModel)
        {
            messageViewModel.Message = Resources.Products.Product.Save;
            TempData["message"] = messageViewModel;
        }
        //
        // GET: /Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
