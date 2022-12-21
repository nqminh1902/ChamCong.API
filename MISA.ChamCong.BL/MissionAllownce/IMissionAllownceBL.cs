using MISA.ChamCong.Common;
using MISA.ChamCong.Common.Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ChamCong.BL
{
   public interface IMissionAllownceBL : IBaseBL<MissionAllownce>
    {
        /// <summary>
        /// Danh sách đơn theo phân trang và tìm kiếm
        /// </summary>
        /// <param name="keyword">Từ khóa cần tìm</param>
        /// <param name="organization">Đơn vị cần tim</param>
        /// <param name="pageSize">Số bản ghi trên một trang</param>
        /// <param name="pageNumber">Vị trí bản ghi bắt đầu</param>
        /// <returns></returns>
        public PaginResults<MissionAllownce> GetMissionByFilterAndPaging(string keyword, string organizationID, int pageSize, int pageNumber);

        /// <summary>
        /// Thêm mới một bản ghi
        /// </summary>
        /// <param name="record">Đối tượng cẩn thêm mới</param>
        /// <returns>ID của đối tượng vừa thêm mới</returns>
        /// CreatedBy: Nguyễn Quang Minh (25/11/2022)
        public ServiceResponse InsertRecord(MissionAllownce record);

        /// <summary>
        /// Sửa thông tin 1 bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn sửa</param>
        /// <param name="record">Đối tượng bản ghi muốn sửa</param>
        /// <returns>ID của bản ghi đã sửa</returns>
        /// CreateBy: Nguyễn Quang Minh (12/11/2022)
        public ServiceResponse UpdateRecord(Guid recordID, MissionAllownce record);

        /// <summary>
        /// Xóa hàng loạt bản ghi theo ID
        /// </summary>
        /// <param name="listEmployeeID">Danh sách ID</param>
        /// <returns>Danh sách ID xóa thành công</returns>
        /// CreateBy: Nguyễn Quang Minh (15/11/2022)
        public ListID DeleteMultipleEmployee(ListID listEmployeeID);
    }
}
