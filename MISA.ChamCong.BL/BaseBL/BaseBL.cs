using MISA.ChamCong.Common;
using MISA.ChamCong.Common.Entities;
using MISA.ChamCong.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ChamCong.BL
{
    public class BaseBL<T> : IBaseBL<T>

    {
        #region Field

        private IBaseDL<T> _baseDL;

        #endregion

        #region Constructor

        public BaseBL(IBaseDL<T> baseDL)
        {
            _baseDL = baseDL;
        }

        #endregion

        #region Method
        /// <summary>
        /// Lấy danh sách tất cả bản ghi
        /// </summary>
        /// <returns>Danh sách tất cả bản ghi</returns>
        /// CreatedBy: Nguyễn Quang Minh (11/11/2022)
        public IEnumerable<T> GetAllRecords()
        {
            return _baseDL.GetAllRecords();
        }

        /// <summary>
        /// Lấy thông tin của 1 bản ghi theo ID
        /// </summary>
        /// <param name="recordID"> Id của bản ghi </param>
        /// <returns>Trả về thông tin của bản ghi</returns>
        /// CreatedBy: Nguyễn Quang Minh (11/11/2022)
        public T GetRecordByID(Guid recordID)
        {
            return _baseDL.GetRecordByID(recordID);
        }

       
        /// <summary>
        /// Xóa 1 bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn xóa</param>
        /// <returns>ID của bản ghi đã bị xóa</returns>
        /// CreateBy: Nguyễn Quang Minh (12/11/2022)
        public Guid DeleteRecord(Guid recordID)
        {
            return _baseDL.DeleteRecord(recordID);
        }
        #endregion

        /// <summary>
        /// Validate dữ liệu
        /// </summary>
        /// <param name="differentiate">Tham số để phân biệt giữa update và insert</param>
        /// <param name="employee">Đối tượng nhân viên cần validate</param>
        /// <returns>Trả về kết quả validate có thành công hay không</returns>
        protected virtual List<string> ValidateRequestData(bool differentiate, T record)
        {
            // Lấy danh sách thuộc tính(property) của class
            var properties = typeof(T).GetProperties();

            // Duyệt từng thuộc tính 
            var validateFailures = new List<string>();


            foreach (var property in properties)
            {
                // Lấy được giá trị thuộc tính đó
                var propertyValue = property.GetValue(record);

                var requiredAttribute = (IsNullOrEmpty?)Attribute.GetCustomAttribute(property, typeof(IsNullOrEmpty));

                var checkDuplicate = (IsDuplicate?)Attribute.GetCustomAttribute(property, typeof(IsDuplicate));

                var checkIsNotNumber = (IsNotNumber?)Attribute.GetCustomAttribute(property, typeof(IsNotNumber));

                var checkValidCode = (IsValidCode?)Attribute.GetCustomAttribute(property, typeof(IsValidCode));

                // Kiểm tra porperty có required không và giá trị từ frondend có null không
                if (requiredAttribute != null && string.IsNullOrEmpty(propertyValue?.ToString()))
                {
                    validateFailures.Add(requiredAttribute.ErrorMessage);
                }


                // Kiểm tra property có lớn hơn 20 ký tự và kết thúc bằng số không
                if (checkValidCode != null && propertyValue?.ToString().Length > 20)
                {
                    validateFailures.Add(checkValidCode.ErrorMessage);
                }

                // Kiểm tra xem property không phải là số nếu là số thì lỗi
                if (checkIsNotNumber != null && int.TryParse(propertyValue.ToString(), out int value))
                {
                    validateFailures.Add(checkIsNotNumber.ErrorMessage);
                }

                //Kiểm tra property có IsDuplicate không và có bị trùng mã nhân viên không 
                //differentiate: true là insert, false là update
                if (checkDuplicate != null && differentiate && propertyValue?.ToString().Length < 20)
                {
                    bool check = _baseDL.CheckCodeExist(propertyValue.ToString(), record);

                    if (check)
                    {

                        validateFailures.Add(checkDuplicate.ErrorMessage);
                    }

                }
            }
            return validateFailures;
        }
    }
}
