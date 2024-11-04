using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Api.Controllers;

[ApiController]
[Authorize]
[Route("api/[controller]")]
public class PersonController : Controller
{
    [HttpGet]
    public IActionResult GetAllPerson()
    {
        return Ok();
    }
}