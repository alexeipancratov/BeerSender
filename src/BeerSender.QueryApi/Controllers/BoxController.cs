using BeerSender.Domain.Boxes;
using BeerSender.QueryApi.Database;
using BeerSender.QueryApi.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeerSender.QueryApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BoxController(BoxQueryRepository boxQueryRepository) : ControllerBase
{
    private readonly BoxQueryRepository _boxQueryRepository = boxQueryRepository;

    [HttpGet]
    [Route("{id}")]
    public Box GetById([FromRoute]Guid id)
    {
        throw new NotImplementedException();
    }

    [HttpGet]
    [Route("{id}/version/{version}")]
    public Box GetById([FromRoute] Guid id, [FromRoute]int version)
    {
        throw new NotImplementedException();
    }
    
    [HttpGet]
    [Route("all-open")]
    public IEnumerable<OpenBox> GetOpenBoxes()
    {
        return _boxQueryRepository.GetAllOpen();
    }

    [HttpGet]
    [Route("all-unsent")]
    public IEnumerable<UnsentBox> GetUnsentBoxes()
    {
        return _boxQueryRepository.GetAllUnsent();
    }
}