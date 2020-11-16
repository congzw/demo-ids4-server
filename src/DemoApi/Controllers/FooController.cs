using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoApi.Controllers
{
    [Route("~/Api/Foo/[action]")]
    public class FooController : ControllerBase
    {
        [AllowAnonymous]
        public string GetInfo()
        {
            return this.GetType().Name;
        }

        public IActionResult GetUser()
        {
            return new JsonResult(from c in User.Claims select new { c.Type, c.Value });
        }
    }
}
