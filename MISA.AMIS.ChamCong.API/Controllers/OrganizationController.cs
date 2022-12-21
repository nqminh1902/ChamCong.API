using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MISA.ChamCong.BL;
using MISA.ChamCong.Common;

namespace MISA.ChamCong.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrganizationController : BaseController<Organization>
    {
        public OrganizationController(IBaseBL<Organization> baseBL) : base(baseBL)
        {

        }
    }
}
