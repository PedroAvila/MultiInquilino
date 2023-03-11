using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiInquilino.Fx.Extensiones;

namespace MultiInquilinoUnicaBaseDatos.Controllers
{
    [ApiController]
    [Route("api/tenants")]
    public class TenantController : ControllerBase
    {
        [HttpGet]
        public ActionResult<string> IActionResult()
        {
            var result = HttpContext.GetTenant()?.Items["Name"];
            return Ok(result);
        }
    }
}
