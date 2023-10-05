using EmployeeManagement.Data.Contacts;
using EmployeeManagement.Data.DataContext;
using EmployeeManagement.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Data.Implementation
{
    public class EmployeeLeaveAllocationRepository : Repository<EmployeeLeaveAllocation>, IEmployeeLeaveAllocationRepository
    {
        private readonly ProjectEmployeeManagementContext _ctx;

        public EmployeeLeaveAllocationRepository(ProjectEmployeeManagementContext ctx)
            :base(ctx)
        {
            _ctx = ctx;
        }
    }
}
