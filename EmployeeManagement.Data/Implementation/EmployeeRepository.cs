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
    public class EmployeeRepository : Repository<Employee>, IEmployeeRepository
    {
        private readonly ProjectEmployeeManagementContext _ctx;

        public EmployeeRepository(ProjectEmployeeManagementContext ctx)
            :base(ctx)
        {
           
        }
    }
}
