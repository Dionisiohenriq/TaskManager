using Microsoft.AspNetCore.Mvc;

namespace TaskManager.Api.Controllers;

[ApiController]
public class PersonController : Controller
{
    [HttpGet]
    public IActionResult GetAllPerson()
    {
        return Ok();
    }
}