using EmployeeManagement.Data.Contacts;
using EmployeeManagement.Data.DataContext;
using EmployeeManagement.Data.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Data.Implementation
{
    public class EmployeeLeaveRequestRepository : Repository<EmployeeLeaveRequest>, IEmployeeLeaveRequestRepository
    {
        private readonly ProjectEmployeeManagementContext _ctx;
        public EmployeeLeaveRequestRepository(ProjectEmployeeManagementContext ctx) : base(ctx)
        {
        }
    }
}
