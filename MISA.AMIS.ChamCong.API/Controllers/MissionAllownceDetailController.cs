using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ChamCong.Common.Entities.DTO;
using MISA.ChamCong.Common;
using MISA.ChamCong.Common.Entities;
using MISA.ChamCong.BL;

namespace MISA.ChamCong.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionAllownceDetailController : BaseController<MissionAllownceDetail>
    {
        private IMissionAllownceDetailBL _missionAllownceDetailBL;
        public MissionAllownceDetailController(IMissionAllownceDetailBL missionAllownceDetailBL) : base(missionAllownceDetailBL)
        {
            _missionAllownceDetailBL = missionAllownceDetailBL;
        }

        /// <summary>
        /// Xóa danh sách đơn theo ID
        /// </summary>
        /// <param name="listEmployeeID">danh sách ID đơn</param>
        /// <returns>Danh sách đơn đã xóa</returns>
        [HttpPost("deleteBatch")]
        public IActionResult DeleteMultipleEmployee([FromBody] ListID listEmployeeID)
        {
            try
            {
                var ListID = _missionAllownceDetailBL.DeleteMultipleEmployee(listEmployeeID);

                if (ListID != null)
                {
                    return StatusCode(StatusCodes.Status200OK, ListID);
                }
                return StatusCode(StatusCodes.Status500InternalServerError, new
                {
                    ErrorCode = 2,
                    DevMsg = Resources.DevMsg_DeleteMultipleFail,
                    UserMsg = Resources.UserMsg_DeleteMultipleFail,
                    MoreInfo = Resources.MoreInfo_Exception,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = AMISErrorCode.Exception,
                    DevMsg = Resources.DevMsg_Exception,
                    UserMsg = Resources.UserMsg_Exception,
                    MoreInfo = Resources.MoreInfo_Exception,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        /// <summary>
        /// lấy Danh sách nhân viên đi công tác cùng
        /// </summary>
        /// <param name="missionAllownceDetailsID">Id đơn</param>
        /// <returns>Danh sách nhân viên</returns>
        [HttpGet("missionID")]
        public IActionResult GetMissionAllownceDetailsByID([FromRoute] Guid missionAllownce)
        {
            try
            {
                var record = _missionAllownceDetailBL.GetMissionAllownceDetailsByID(missionAllownce);

                // Xử lý trả về

                // Thành công: Trả về dữ liệu cho FE
                if (record != null)
                {
                    return StatusCode(StatusCodes.Status200OK, record);
                }
                // Thất bại
                return StatusCode(StatusCodes.Status404NotFound);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = AMISErrorCode.Exception,
                    DevMsg = Resources.DevMsg_Exception,
                    UserMsg = Resources.UserMsg_Exception,
                    MoreInfo = Resources.MoreInfo_Exception,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }

        /// <summary>
        /// Thêm nhiều bản ghi vào bảng người đi làm cùng
        /// </summary>
        /// <param name="missionAllownceDetails">Danh sách người đi làm cùng</param>
        /// <returns>Danh sách ID thêm thành công</returns>
        [HttpPost("insertMultiple")]
        public IActionResult InsertMultipleMissionDetail([FromBody] List<MissionAllownceDetail> missionAllownceDetails)
        {

            try
            {
                var ids = _missionAllownceDetailBL.InsertMultipleMissionDetail(missionAllownceDetails);

                if (ids.Count > 0)
                {
                    return StatusCode(StatusCodes.Status201Created, ids);
                }
                return StatusCode(StatusCodes.Status400BadRequest, new
                {
                    ErrorCode = AMISErrorCode.InValidData,
                    DevMsg = Resources.DevMsg_Required,
                    UserMsg = Resources.UserMsg_InsertMultipleFail,
                    MoreInfo = Resources.MoreInfo_Exception,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, new ErrorResult
                {
                    ErrorCode = AMISErrorCode.Exception,
                    DevMsg = Resources.DevMsg_Exception,
                    UserMsg = Resources.UserMsg_Exception,
                    MoreInfo = Resources.MoreInfo_Exception,
                    TraceId = HttpContext.TraceIdentifier
                });
            }
        }
    }
}
