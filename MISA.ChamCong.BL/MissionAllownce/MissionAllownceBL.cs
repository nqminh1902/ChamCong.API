using MISA.ChamCong.Common;
using MISA.ChamCong.Common.Entities.DTO;
using MISA.ChamCong.DL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ChamCong.BL
{
    public class MissionAllownceBL : BaseBL<MissionAllownce>, IMissionAllownceBL
    {
        private IMissionAllownceDL _missionAllownceDL;

        public MissionAllownceBL(IMissionAllownceDL missionAllownce) : base(missionAllownce)
        {
            _missionAllownceDL = missionAllownce;
        }

        /// <summary>
        /// Danh sách đơn theo phân trang và tìm kiếm
        /// </summary>
        /// <param name="keyword">Từ khóa cần tìm</param>
        /// <param name="organization">Đơn vị cần tim</param>
        /// <param name="pageSize">Số bản ghi trên một trang</param>
        /// <param name="pageNumber">Vị trí bản ghi bắt đầu</param>
        /// <returns></returns>
        public PaginResults<MissionAllownce> GetMissionByFilterAndPaging(string keyword, string organizationID, int pageSize, int pageNumber)
        {
            return _missionAllownceDL.GetMissionByFilterAndPaging(keyword, organizationID, pageSize, pageNumber);
        }

        /// <summary>
        /// Thêm mới một bản ghi
        /// </summary>
        /// <param name="record">Đối tượng cẩn thêm mới</param>
        /// <returns>ID của đối tượng vừa thêm mới</returns>
        /// CreatedBy: Nguyễn Quang Minh (25/11/2022)
        public ServiceResponse InsertRecord(MissionAllownce record)
        {
          /*  // Gọi đến hàm để validate dữ liệu
            var validateResult = ValidateRequestData(true, record);


            // Nếu Fail thì trả về lỗi
            if (validateResult.Count > 0)
            {
                return new ServiceResponse()
                {
                    Data = validateResult,
                    Success = false,
                };
            }
            else
            {*/
                // Thực hiện gọi làm thêm bản ghi và trả về kết quả
                var employeeID = _missionAllownceDL.InsertRecord(record);
                return new ServiceResponse()
                {
                    Success = true,
                    ID = employeeID
                };

            //}
        }

        /// <summary>
        /// Sửa thông tin 1 bản ghi theo ID
        /// </summary>
        /// <param name="recordID">ID của bản ghi muốn sửa</param>
        /// <param name="record">Đối tượng bản ghi muốn sửa</param>
        /// <returns>ID của bản ghi đã sửa</returns>
        /// CreateBy: Nguyễn Quang Minh (12/11/2022)
        public ServiceResponse UpdateRecord(Guid recordID, MissionAllownce record)
        {
            // Gọi đến hàm để validate dữ liệu
            var validateResult = ValidateRequestData(false, record);

            // Nếu Fail thì trả về lỗi
            if (validateResult.Count > 0)
            {
                return new ServiceResponse()
                {
                    Data = validateResult,
                    Success = false,
                };
            }
            else
            {
                // Thực hiện gọi hàm sửa bản ghi và trả về kết quả
                var employeeIDUpdate = _missionAllownceDL.UpdateRecord(recordID, record);
                return new ServiceResponse()
                {
                    Success = true,
                    ID = employeeIDUpdate
                };
            }
        }

        /// <summary>
        /// Xóa hàng loạt bản ghi theo ID
        /// </summary>
        /// <param name="listEmployeeID">Danh sách ID</param>
        /// <returns>Danh sách ID xóa thành công</returns>
        /// CreateBy: Nguyễn Quang Minh (15/11/2022)
        public ListID DeleteMultipleEmployee(ListID listEmployeeID)
        {
            return _missionAllownceDL.DeleteMultipleEmployee(listEmployeeID);
        }
    }
}
