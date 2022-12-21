using MISA.ChamCong.Common.Entities;
using MISA.ChamCong.Common.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ChamCong.Common
{
    public class MissionAllownce:BaseEntities
    {
        /// <summary>
        /// Id đơn đi công tác
        /// </summary>
        [Key]        
        public Guid? MissionAllowanceID { get; set; }

        /// <summary>
        /// Id nhân viên
        /// </summary>
        public Guid EmployeeID { get; set; }

        /// <summary>
        /// Mã nhân viên
        /// </summary>
        public string EmployeeCode { get; set; }

        /// <summary>
        /// Tên nhân viên
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// ID đơn vị
        /// </summary>
        public Guid OrganizationUnitID { get; set; }

        /// <summary>
        /// Tên đơn vị
        /// </summary>
        public string OrganizationUnitName { get; set; }

        /// <summary>
        /// ID vị trí
        /// </summary>
        public Guid JobPositionID { get; set; }

        /// <summary>
        /// Tên vị trí
        /// </summary>
        public string JobPositionName { get; set; }

        /// <summary>
        /// Ngày yêu cầu
        /// </summary>
        public DateTime RequestDate { get; set; }

        /// <summary>
        /// Ngày bắt đầu
        /// </summary>
        public DateTime ToDate { get; set; }

        /// <summary>
        /// Ngày kết thúc
        /// </summary>
        public DateTime FromDate { get; set; }

        /// <summary>
        /// Số ngày đi công tác
        /// </summary>
        public string LeaveDay { get; set; }

        /// <summary>
        /// Địa điểm
        /// </summary>
        public string Location { get; set; }

        /// <summary>
        /// Lý do đi công tác
        /// </summary>
        public string Purpose { get; set; }

        /// <summary>
        /// Yêu cầu hỗ trợ
        /// </summary>
        public string Request { get; set; }

        /// <summary>
        /// Danh sách ID người hỗ trợ
        /// </summary>
        public string SupportIDs { get; set; }

        /// <summary>
        /// Danh sách tên người hỗ trợ
        /// </summary>
        public string SupportNames { get; set; }

        /// <summary>
        /// ID người duyệt
        /// </summary>
        public Guid ApprovalToID { get; set; }

        /// <summary>
        /// Tên người duyệt
        /// </summary>
        public string ApprovalName { get; set; }

        /// <summary>
        /// Danh sách ID người liên quan
        /// </summary>
        public string RelationShipIDs { get; set; }

        /// <summary>
        /// Danh sách tên người liên quan
        /// </summary>
        public string RelationShipNames { get; set; }

        /// <summary>
        /// Trạng thái đơn
        /// </summary>
        public Status Status { get; set; }

    }
}
