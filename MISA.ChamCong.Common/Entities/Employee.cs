using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ChamCong.Common
{
    public class Employee : BaseEntities
    {
        /// <summary>
        /// ID nhân viên
        /// </summary>
        public Guid EmployeeID { get; set; }

        /// <summary>
        ///Mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Giới tính
        /// </summary>
        public Gender? Gender { get; set; }

        /// <summary>
        /// Ngày sinh
        /// </summary>
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Địa chỉ
        /// </summary>
        public string CurrentAddress { get; set; }

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string MobilePhone { get; set; }

        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// ID vị trí
        /// </summary>
        public Guid JobPositionID { get; set; }

        /// <summary>
        /// Tên vị trí
        /// </summary>
        public string JobPositionName { get; set; }

        /// <summary>
        /// ID đơn vị
        /// </summary>
        public Guid OrganizationUnitID { get; set; }

        /// <summary>
        /// Tên đơn vị
        /// </summary>
        public string OrganizationUnitName { get; set; }
    }
}
