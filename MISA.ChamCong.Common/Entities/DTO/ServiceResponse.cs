using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ChamCong.Common
{
    /// <summary>
    /// Kết quả trả về sau khi validate dữ liệu
    /// </summary>
    public class ServiceResponse
    {
        /// <summary>
        /// Có lỗi hay không nếu có trả về false, không thì trả về true
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// Danh sách lỗi
        /// </summary>
        public List<string>? Data { get; set; }

        /// <summary>
        /// ID của bản ghi
        /// </summary>
        public Guid? ID { get; set; }
    }
}
