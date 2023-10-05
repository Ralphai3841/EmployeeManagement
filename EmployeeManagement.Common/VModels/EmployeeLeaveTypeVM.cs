using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Common.VModels
{
    public class EmployeeLeaveTypeVM : BaseVM
    {
        [Required]
        public string Name { get; set; }
        public int DefaultDays { get; set; }
        public DateTime DateCreated { get; set; }
        public bool IsActive { get; set; }

        //MVVM Create EmployeeType
        public void SetEmployeeType(string name)
        {
            this.Name = name;
        }
    }
}
