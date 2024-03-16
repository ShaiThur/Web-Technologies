using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProductivity.Server.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        protected ISender _sender;

        public BaseController(ISender sender)
        {
            _sender = sender;
        }
    }
}
