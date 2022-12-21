using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ChamCong.BL;
using MISA.ChamCong.Common;

namespace MISA.ChamCong.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobPositionController : BaseController<JobPosition>
    {
        #region Constructor

        public JobPositionController(IBaseBL<JobPosition> baseBL) : base(baseBL)
        {

        }

        #endregion
    }
}
