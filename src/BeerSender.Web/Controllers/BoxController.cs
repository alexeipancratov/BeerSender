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
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public IActionResult Create([FromBody] CreateBoxCommand command)
    {
        // TODO: Map an external object to the command instead of receiving it directly.
        _commandRouter.HandleCommand(command);

        // It won't necessarily be processed immediately, e.g., if we later decide to scale it and queue up commands
        // to execute them in parallel when resources become available.
        return Accepted();
    }
    
    [HttpPost]
    [Route("add-bottle")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public IActionResult CreateBox([FromBody]AddBeerBottleCommand command)
    {
        _commandRouter.HandleCommand(command);
        return Accepted();
    }
    
    [HttpPost]
    [Route("add-label")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public IActionResult CreateBox([FromBody]AddShippingLabelCommand command)
    {
        _commandRouter.HandleCommand(command);
        return Accepted();
    }
    
    [HttpPost]
    [Route("close")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public IActionResult CreateBox([FromBody]CloseBoxCommand command)
    {
        _commandRouter.HandleCommand(command);
        return Accepted();
    }
    
    [HttpPost]
    [Route("ship")]
    [ProducesResponseType(StatusCodes.Status202Accepted)]
    public IActionResult CreateBox([FromBody]ShipBoxCommand command)
    {
        _commandRouter.HandleCommand(command);
        return Accepted();
    }
}