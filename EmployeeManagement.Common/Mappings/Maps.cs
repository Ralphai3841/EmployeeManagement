using AutoMapper;
using EmployeeManagement.Common.VModels;
using EmployeeManagement.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Common.Mappings
{
    public class Maps : Profile
    {
        public Maps()
        {
            CreateMap<EmployeeLeaveType, EmployeeLeaveTypeVM>().ReverseMap(); 
            //CreateMap<EmployeeLeaveTypeVM, EmployeeLeaveType>(); 
            CreateMap<EmployeeLeaveAllocation, EmployeeLeaveAllocationsVM>().ReverseMap(); 
            CreateMap<EmployeeLeaveRequest, EmployeeLeaveRequestVM>().ReverseMap(); 
            CreateMap<Employee, EmployeeVM>().ReverseMap(); 
        }
    }
}
