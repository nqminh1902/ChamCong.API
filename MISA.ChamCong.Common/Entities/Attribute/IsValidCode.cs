using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ChamCong.Common
{
    /// <summary>
    /// Hàm trả về lỗi nếu ID nhập không hợp lệ
    /// </summary>
    public class IsValidCode : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            return new ValidationResult(this.ErrorMessage);
        }
    }
}
