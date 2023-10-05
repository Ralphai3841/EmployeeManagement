using EmployeeManagement.Data.Contacts;
using EmployeeManagement.Data.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Data.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProjectEmployeeManagementContext _ctx;

        public UnitOfWork(ProjectEmployeeManagementContext ctx)
        {
            _ctx = ctx;
            employeeLeaveAllocation = new EmployeeLeaveAllocationRepository(_ctx);
            employeeLeaveRequestRepository = new EmployeeLeaveRequestRepository(_ctx);
            employeeLeaveTypeRepository = new EmployeeLeaveTypeRepository(_ctx);
            employeeRepository = new EmployeeRepository(_ctx);
        }

        public IEmployeeLeaveAllocationRepository employeeLeaveAllocation { get; private set; }
        public IEmployeeLeaveRequestRepository employeeLeaveRequestRepository { get; private set; }
        public IEmployeeLeaveTypeRepository employeeLeaveTypeRepository { get; private set; }
        public IEmployeeRepository employeeRepository { get; private set; }
        public void Dispose()
        {
            _ctx.Dispose();
        }

        public void Save()
        {
            _ctx.SaveChanges();
        }
    }
}
