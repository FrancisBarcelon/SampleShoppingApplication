using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SampleShoppingApplication.Controllers
{
    [Authorize]
    public class BaseController : Controller
    {
        
    }
}
