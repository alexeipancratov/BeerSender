using BeerSender.Domain;
using BeerSender.Domain.Boxes;
using BeerSender.QueryApi.Database;
using BeerSender.QueryApi.Database.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeerSender.QueryApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BoxController(IEventStore eventStore, BoxQueryRepository boxQueryRepository) : ControllerBase
{
    private readonly IEventStore _eventStore = eventStore;
    private readonly BoxQueryRepository _boxQueryRepository = boxQueryRepository;

    [HttpGet]
    [Route("{id}")]
    public Box GetById([FromRoute]Guid id)
    {
        var eventStream = new EventStream<Box>(_eventStore, id);
        return eventStream.GetEntity();
    }

    [HttpGet]
    [Route("{id}/version/{version}")]
    public Box GetById([FromRoute] Guid id, [FromRoute]int version)
    {
        var eventStream = new EventStream<Box>(_eventStore, id);
        return eventStream.GetEntity(version);
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