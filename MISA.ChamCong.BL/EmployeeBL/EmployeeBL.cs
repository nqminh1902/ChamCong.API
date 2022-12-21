using MISA.ChamCong.Common;
using MISA.ChamCong.Common.Entities;
using MISA.ChamCong.Common.Entities.DTO;
using MISA.ChamCong.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MISA.ChamCong.BL
{
    public class EmployeeBL : BaseBL<Employee>, IEmployeeBL
    {
        #region Field
        private IEmployeeDL _employeeDL;
        #endregion

        #region Constructor
        public EmployeeBL(IEmployeeDL employeeDL) : base(employeeDL)
        {
            _employeeDL = employeeDL;
        }
        #endregion

        #region Method
        /// <summary>
        /// Danh sách bản ghi theo tìm kiếm và phân trang
        /// </summary>
        /// <param name="keyword">Từ cần tìm kiếm</param>
        /// <param name="pageSize">Số bản ghi trên 1 trang</param>
        /// <param name="pageNumber">Vị trí của bản ghi bắt đầu</param>
        /// <returns></returns>
        public PaginResults<Employee> GetEmployeeByFilterAndPaging(string? keyword, int pageSize, int pageNumber)
        {
            return _employeeDL.GetEmployeeByFilterAndPaging(keyword, pageSize, pageNumber);
        }

        /// <summary>
        /// Lấy mã nhân viên mới nhất
        /// </summary>
        /// <returns>Mã nhân viên mới nhất</returns>
        public string GetNewCode()
        {
            return _employeeDL.GetNewCode();
        }

        /// <summary>
        /// Xóa hàng loạt bản ghi theo ID
        /// </summary>
        /// <param name="listEmployeeID">Danh sách ID</param>
        /// <returns>Danh sách ID xóa thành công</returns>
        /// CreateBy: Nguyễn Quang Minh (15/11/2022)
        public ListID DeleteMultipleEmployee(ListID listEmployeeID)
        {
            return _employeeDL.DeleteMultipleEmployee(listEmployeeID);
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="differentiate"></param>
        /// <param name="record"></param>
        /// <returns></returns>
        protected override List<string> ValidateRequestData(bool differentiate, Employee record)
        {
            var validate = base.ValidateRequestData(differentiate, record);
            // Lấy danh sách thuộc tính(property) của class
            var properties = typeof(Employee).GetProperties();

            // Duyệt từng thuộc tính 

            var validateFailures = validate;

            foreach (var property in properties)
            {
                // Lấy được giá trị thuộc tính đó
                var propertyValue = property.GetValue(record);

                var checkEmail = (IsEmail?)Attribute.GetCustomAttribute(property, typeof(IsEmail));

                var checkDateOfBirth = (IsValidDateOfBirth?)Attribute.GetCustomAttribute(property, typeof(IsValidDateOfBirth));

                var checkIsNumber = (IsNumber?)Attribute.GetCustomAttribute(property, typeof(IsNumber));

                // Kiểm tra property có IsEmail không và có đúng định dạng email không
                if (checkEmail != null && propertyValue?.ToString() != null && propertyValue.ToString()?.Trim() != "")
                {
                    bool isEmail = IsValidEmail(propertyValue.ToString());
                    if (!isEmail)
                    {
                        validateFailures.Add(checkEmail.ErrorMessage);

                    }
                }

                if (checkDateOfBirth != null)
                {
                    var dateValue = propertyValue as DateTime? ?? new DateTime();

                    //alter this as needed. I am doing the date comparison if the value is not null

                    if (dateValue.Date > DateTime.Now.Date)
                    {
                        validateFailures.Add(checkDateOfBirth.ErrorMessage);
                    }
                }

                // Kiểm tra xem property có phải là số không
                if (checkIsNumber != null && !string.IsNullOrEmpty(propertyValue.ToString().Trim()))
                {
                    if (!int.TryParse(propertyValue.ToString(), out int m))
                    {
                        validateFailures.Add(checkIsNumber.ErrorMessage);
                    }
                }
            }



            return validateFailures;
        }

        /// <summary>
        /// Check định dạng email
        /// </summary>
        /// <param name="email">Dữ liệu chuỗi email đầu vào</param>
        /// <returns>Nếu đúng thì trả về true, ngược lại false</returns>
        private static bool IsValidEmail(string email)
        {
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            Match match = regex.Match(email);
            if (email.Trim().EndsWith("."))
            {
                return false;
            }
            if (match.Success)
            {
                return true;
            }
            return false;
        }
    }
}
