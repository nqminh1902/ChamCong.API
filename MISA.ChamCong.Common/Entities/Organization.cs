using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MISA.ChamCong.Common
{
    public class Organization:BaseEntities
    {
        /// <summary>
        /// ID đơn vị
        /// </summary>
        public Guid OrganizationUnitID { get; set; }

        /// <summary>
        /// Mã đơn vị
        /// </summary>
        public string OrganizationUnitCode { get; set; }

        /// <summary>
        /// Tên đơn vị
        /// </summary>
        public string OrganizationUnitName { get; set; }

        /// <summary>
        /// Mã Misa
        /// </summary>
        public string MisaCode { get; set; }
    }
}
