using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ChamCong.Common.Entities
{
    public class MissionAllownceDetail:BaseEntities
    {
        /// <summary>
        /// ID chi tiết nhân viên đi công tác cùng
        /// </summary>
        [Key]
        public Guid? MissionAllowanceDetailID { get; set; }

        /// <summary>
        /// ID đơn công tác
        /// </summary>
        public Guid MissionAllowanceID { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }

        /// <summary>
        /// ID nhân viên
        /// </summary>
        public Guid EmployeeID { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        public string EmployeeName { get; set; }

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

        /// <summary>
        /// Số điện thoại
        /// </summary>
        public string MobilePhone { get; set; }
    }
}
