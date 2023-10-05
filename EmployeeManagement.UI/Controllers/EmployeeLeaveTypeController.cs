using EmployeeManagement.BusinessEngine.Contracts;
using EmployeeManagement.Common.ConstantsModels;
using EmployeeManagement.Common.VModels;
using EmployeeManagement.Data.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.UI.Controllers
{
    [Authorize(Roles = ResultConstant.Admin_Role)]
    public class EmployeeLeaveTypeController : Controller
    {
        

        private readonly IEmployeeLeaveTypeBusinessEngine _employeeLeaveTypeBusinessEngine;

        public EmployeeLeaveTypeController(IEmployeeLeaveTypeBusinessEngine employeeLeaveTypeBusinessEngine)
        {
            _employeeLeaveTypeBusinessEngine = employeeLeaveTypeBusinessEngine;
        }

        
        public IActionResult Index()
        {
            var data = _employeeLeaveTypeBusinessEngine.GetAllEmployeeLeaveTypes();
            if (!data.IsSuccess)
            {
                return View();
            }
            var result = data.Data;
            return View(result);
        }

        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        public  ActionResult Create(EmployeeLeaveTypeVM model)
        {
            if (ModelState.IsValid)
            {
                var data = _employeeLeaveTypeBusinessEngine.CreateEmployeeLeaveType(model);
                if (data.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            else
                return View(model);
            
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id < 0)
                return View();

            var data = _employeeLeaveTypeBusinessEngine.GetAllEmployeeLeaveTypes(id);
            if (data.IsSuccess)
                return View(data.Data);
            return View();
        }
        
        [ValidateAntiForgeryToken]
        [HttpPost]
        public  ActionResult Edit(EmployeeLeaveTypeVM model)
        {
            if (ModelState.IsValid)
            {
                var data = _employeeLeaveTypeBusinessEngine.EditEmployeeLeaveType(model);
                if (data.IsSuccess)
                {
                    return RedirectToAction("Index");
                }
                return View(model);
            }
            else
                return View(model);
            
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return Json(new { success = false, message = "Silmek için Kayıt Seçiniz" });
            
              var data = _employeeLeaveTypeBusinessEngine.RemoveEmployeeLeaveType(id);
             if (data.IsSuccess)
                 return Json(new { success = data.IsSuccess, message = data.Message });
              else
                 return Json(new { success = data.IsSuccess, message = data.Message });
        }
    }
}
