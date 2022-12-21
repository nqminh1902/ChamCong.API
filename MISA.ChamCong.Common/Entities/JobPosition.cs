using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ChamCong.Common
{
    public class JobPosition:BaseEntities
    {
        /// <summary>
        /// ID vị trí
        /// </summary>
        public Guid JobPositionID { get; set; }

        /// <summary>
        /// Mã vị trí
        /// </summary>
        public string JobPositionCode { get; set; }

        /// <summary>
        /// Tên vị trí
        /// </summary>
        public string JobPositionName { get; set; }
    }
}
