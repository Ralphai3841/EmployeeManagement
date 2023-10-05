using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.BusinessEngine.ResultModels
{
    public class Result<T> : IResult
    {
        private bool v;
        private object p;

        public bool IsSuccess { get ; set; }
        public string Message { get; set ; }

        public T Data { get; set; }

        public int TotalCount { get; set; }

        public Result(bool isSuccess, string message, List<Data.DbModels.EmployeeLeaveType> returnData)
            : this(isSuccess, message, default(T))
        {

        }

        public Result(bool isSuccess, string message, T data)
            : this(isSuccess, message, data, 0)
        {

        }

        public Result(bool isSuccess, string message, T data, int totalCount)
        {
            IsSuccess = isSuccess;
            Message = message;
            Data = data;
            TotalCount = totalCount;
        }

        public Result(bool v, object p)
        {
            this.v = v;
            this.p = p;
        }
    }
}
