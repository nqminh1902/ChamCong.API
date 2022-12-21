using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ChamCong.Common
{
    public class PaginResults<T>
    {
        /// <summary>
        /// Danh sách bản ghi
        /// </summary>
        public List<T>? Data { get; set; }

        /// <summary>
        ///  tổng số bản ghi
        /// </summary>
        public long TotalCount { get; set; }
    }
}
