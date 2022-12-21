using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ChamCong.Common
{
    public class Procedure
    {
        /// <summary>
        /// Format tên của procedure lấy tất cả bản ghi
        /// </summary>
        public static string GET_ALL = "Proc_{0}_GetAll";

        /// <summary>
        /// Format tên của procedure lấy bản ghi theo ID
        /// </summary>
        public static string GET_BY_ID = "Proc_{0}_GetByID";

        /// <summary>
        /// Format tên của procedure xóa 1 bản ghi theo ID
        /// </summary>
        public static string DELETE = "Proc_{0}_Delete";

        /// <summary>
        /// Tên của procedure sửa bản ghi
        /// </summary>
        public static string UPDATE_RECORD = "Proc_{0}_Update";

        /// <summary>
        /// Tên của procedure thêm bản ghi
        /// </summary>
        public static string INSERT_RECORD = "Proc_{0}_Insert";

        /// <summary>
        /// Tên của procedure Lấy mã nhân viên mới nhất
        /// </summary>
        public static string GET_NEW_EMPLOYEE_CODE = "Proc_employee_NewCode";

        /// <summary>
        /// Tên của procedure phân trang và tìm kiếm nhân viên
        /// </summary>
        public static string GET_BY_FILTER_PAGING = "Proc_employee_GetPaging";

        /// <summary>
        /// Tên của procedure phân trang vô cực và tim kiếm nhân viên
        /// </summary>
        public static string GET_BY_PAGING_INFINITY = "Proc_employee_InfinityPaging";

        /// <summary>
        /// Tên của procedure phân và tìm kiếm đơn đi công tác
        /// </summary>
        public static string GET_MISSION_BY_PAGING = "Proc_MissionAllownce_GetPaging";

        /// <summary>
        /// Tên của procedure tìm mã nhân viên
        /// </summary>
        public static string GET_CODE_BY_CODE = "Proc_{0}_GetSameID";

        /// <summary>
        /// Tên của procedure thêm đơn đi công tác
        /// </summary>
        public static string INSERT_MISSION_ALLOWNCE = "Proc_MissionAllownce_Insert";

        /// <summary>
        /// Tên của procedure sủa đơn đi công tác
        /// </summary>
        public static string UPDATE_MISSION_ALLOWNCE = "Proc_MissionAllownce_Update";

        /// <summary>
        /// lấy danh sách chi tiết người đi công tác cùng 
        /// </summary>
        public static string GET_MISSION_DETAIL_BY_ID = "Proc_missionallowancedetail_GetByID";
    }
}
