using Microsoft.AspNetCore.Mvc;

namespace RotativeDownloadApp.Controllers;

[ApiController]
[Route("/")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public string Index()
    {
        return "Aplikasi berjalan! Gunakan /download/excel atau /download/pdf";
    }
}