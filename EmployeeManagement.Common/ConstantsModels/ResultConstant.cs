using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeManagement.Common.ConstantsModels
{
    public static class ResultConstant
    {
        public const string RecordFound = "Kayıt Bulundu";
        public const string RecordNotFound = "Kayıt Bulunamadı";
        public const string RecordCreateSuccessfully = "Kayıt Başarılı";
        public const string RecordCreateNotSuccessfully = "Kayıt Gerçekleştirilirken hata oluştu";


        public const string Admin_Role = "Administrator";
        public const string Employee_Role = "Employee";

        public const string Admin_Email = "ralpdem@gmail.com";
        public const string Admin_Password = "Admin1919!";

        public static string LoginUserInfo { get; set; }
    }
}
