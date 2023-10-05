using EmployeeManagement.BusinessEngine.ResultModels;
using EmployeeManagement.Data.DbModels;
using EmployeeManagement.Common.VModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.BusinessEngine.Contracts
{
    public interface IEmployeeLeaveTypeBusinessEngine
    {
        Result<List<EmployeeLeaveTypeVM>> GetAllEmployeeLeaveTypes();
        Result<EmployeeLeaveTypeVM> CreateEmployeeLeaveType(EmployeeLeaveTypeVM model);

        /// <summary>
        /// Get Employee Leave Type By Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Result<EmployeeLeaveTypeVM> GetAllEmployeeLeaveTypes(int id);

        Result<EmployeeLeaveTypeVM> EditEmployeeLeaveType(EmployeeLeaveTypeVM model);
        object GetAllEmployeeLeaveType();

        Result<EmployeeLeaveTypeVM> RemoveEmployeeLeaveType(int id);
    }
}
