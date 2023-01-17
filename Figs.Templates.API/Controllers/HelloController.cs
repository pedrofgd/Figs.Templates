using Microsoft.AspNetCore.Mvc;

namespace Figs.Templates.API.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloController : ControllerBase
{
    [HttpGet(Name = "HelloWorld")]
    public string Get()
    {
        return "Hello World!";
    }
}
