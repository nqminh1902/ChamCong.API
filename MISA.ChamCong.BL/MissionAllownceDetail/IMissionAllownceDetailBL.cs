using MISA.ChamCong.Common.Entities;
using MISA.ChamCong.Common.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ChamCong.BL
{
    public interface IMissionAllownceDetailBL : IBaseBL<MissionAllownceDetail>
    {
        /// <summary>
        /// Xóa hàng loạt bản ghi theo ID
        /// </summary>
        /// <param name="listEmployeeID">Danh sách ID</param>
        /// <returns>Danh sách ID xóa thành công</returns>
        /// CreateBy: Nguyễn Quang Minh (15/11/2022)
        public ListID DeleteMultipleEmployee(ListID listEmployeeID);

        /// <summary>
        /// lấy Danh sách nhân viên đi công tác cùng
        /// </summary>
        /// <param name="missionAllownceDetailsID">Id đơn</param>
        /// <returns>Danh sách nhân viên</returns>
        public List<MissionAllownceDetail> GetMissionAllownceDetailsByID(Guid missionAllownceDetailsID);

        /// <summary>
        /// Thêm nhiều bản ghi vào bảng người đi làm cùng
        /// </summary>
        /// <param name="missionAllownceDetails">Danh sách bản ghi</param>
        /// <returns>Trả về danh sách id thêm thành công</returns>
        public List<Guid> InsertMultipleMissionDetail(List<MissionAllownceDetail> missionAllownceDetails);
    }

    
}
