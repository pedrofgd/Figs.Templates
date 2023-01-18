using Microsoft.AspNetCore.Mvc;

namespace Figs.Templates.API.Controllers;

[ApiController]
[Route("[controller]")]
public class HelloReversedController : ControllerBase
{
    [HttpGet(Name = "ReversedHelloWorld")]
    public string Get()
    {
        var text = "Hello World!".ToCharArray();
        Array.Reverse(text);
        return new string(text);
    }
}