using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ChamCong.Common.Enums
{
    /// <summary>
    /// Trạng thái
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// Chờ duyệt
        /// </summary>
        Pending = 0,

        /// <summary>
        /// Đã duyệt
        /// </summary>
        Approved = 1,

        /// <summary>
        /// Từ chối
        /// </summary>
        Refuse = 2,
    }
}
