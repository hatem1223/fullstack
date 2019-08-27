using Microsoft.AspNetCore.Antiforgery;
using SmartCompany.Controllers;

namespace SmartCompany.Web.Host.Controllers
{
    public class AntiForgeryController : SmartCompanyControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
