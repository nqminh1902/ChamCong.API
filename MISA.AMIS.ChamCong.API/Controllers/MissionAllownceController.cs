using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ChamCong.BL;
using MISA.ChamCong.Common;
using MISA.ChamCong.Common.Entities.DTO;

namespace MISA.ChamCong.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MissionAllownceController : BaseController<MissionAllownce>
    {

        private IMissionAllownceBL _missionAllownceBL;

        public MissionAllownceController(IMissionAllownceBL missionAllownceBL) : base(missionAllownceBL)
        {
            _missionAllownceBL = missionAllownceBL;
        }

        /// <summary>
        /// Danh sách đơn theo tìm kiếm và phân trang
        /// </summary>
        /// <param name="keyword">Từ khóa cần tìm kiếm</param>
        /// <param name="organizationID">Đơn vị cần tìm kiếm</param>
        /// <param name="pageSize">Số bản ghi</param>
        /// <param name="pageNumber">Vị trí bản ghi bắt đầu</param>
        /// <returns></returns>
        [HttpGet("filter")]
        public IActionResult GetMissionByFilterAndPaging(string? keyword, string? organizationID, int pageSize = 15, int pageNumber = 1)
        {
            try
            {

                var multipleResult = _missionAllownceBL.GetMissionByFilterAndPaging(keyword, organizationID, pageSize, pageNumber);

                if (multipleResult != null)
                {
                    return StatusCode(StatusCodes.Status200OK, multipleResult);
                }
                // Thất bại
                return StatusCode(StatusCodes.Status200OK, new PaginResults<MissionAllownce>());
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
        /// Thêm mới 1 bản ghi
        /// </summary>
        /// <param name="record">Chi tiết bản ghi</param>
        /// <returns>ID bản ghi thêm thành công</returns>
        /// CreateBy: Nguyễn Quang Minh(25/11/2022)
        [HttpPost]
        public IActionResult InsertRecord([FromBody] MissionAllownce record)
        {
            try
            {
                var isValid = _missionAllownceBL.InsertRecord(record);


                //Xử lý kết quả trả về
                if (!isValid.Success)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new
                    {
                        ErrorCode = AMISErrorCode.InValidData,
                        DevMsg = Resources.DevMsg_Required,
                        UserMsg = isValid.Data,
                        MoreInfo = Resources.MoreInfo_Exception,
                        TraceId = HttpContext.TraceIdentifier
                    });

                }
                return StatusCode(StatusCodes.Status201Created, isValid.ID);


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
        /// Cập nhật thông tin 1 bản ghi
        /// </summary>
        /// <param name="recordID">ID của bản ghi</param>
        /// <param name="record">Chi tiết bản ghi</param>
        /// <returns>ID của bản ghi vừa cập nhập</returns>
        /// CreateBy: Nguyễn Quang Minh (25/11/2022)
        [HttpPut("{recordID}")]
        public IActionResult UpdateRecord([FromRoute] Guid recordID, [FromBody] MissionAllownce record)
        {
            try
            {
                var isValid = _missionAllownceBL.UpdateRecord(recordID, record);


                //Xử lý kết quả trả về
                if (!isValid.Success)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, new
                    {
                        ErrorCode = AMISErrorCode.InValidData,
                        DevMsg = Resources.DevMsg_Required,
                        UserMsg = isValid.Data,
                        MoreInfo = Resources.MoreInfo_Exception,
                        TraceId = HttpContext.TraceIdentifier
                    });

                }
                return StatusCode(StatusCodes.Status201Created, isValid.ID);
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
        /// Xóa danh sách đơn theo ID
        /// </summary>
        /// <param name="listEmployeeID">danh sách ID đơn</param>
        /// <returns>Danh sách đơn đã xóa</returns>
        [HttpPost("deleteBatch")]
        public IActionResult DeleteMultipleEmployee([FromBody] ListID listEmployeeID)
        {
            try
            {
                var ListID = _missionAllownceBL.DeleteMultipleEmployee(listEmployeeID);

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
    }
}
