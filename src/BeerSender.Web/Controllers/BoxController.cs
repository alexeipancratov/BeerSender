using BeerSender.Domain;
using BeerSender.Domain.Boxes.Commands;
using Microsoft.AspNetCore.Mvc;

namespace BeerSender.Web.Controllers;

[ApiController]
[Route("api/command/[controller]")]
public class BoxController(CommandRouter commandRouter) : ControllerBase
{
    private readonly CommandRouter _commandRouter = commandRouter;

    [HttpPost]
    [Route("create")]
    public IActionResult Create([FromBody] CreateBoxCommand command)
    {
        // TODO: Map an external object to the command instead of receiving it directly.
        _commandRouter.HandleCommand(command);

        // It won't necessarily be processed immediately, e.g., if we later decide to scale it and queue up commands
        // to execute them in parallel when resources become available.
        return Accepted();
    }
}