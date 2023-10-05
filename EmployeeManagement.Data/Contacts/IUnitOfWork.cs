using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Data.Contacts
{
    public interface IUnitOfWork : IDisposable 
    {
         IEmployeeLeaveAllocationRepository employeeLeaveAllocation { get;  }
         IEmployeeLeaveRequestRepository employeeLeaveRequestRepository { get;  }
         IEmployeeLeaveTypeRepository employeeLeaveTypeRepository { get;  }
         IEmployeeRepository employeeRepository { get;  }
        void Save();
    }
}
