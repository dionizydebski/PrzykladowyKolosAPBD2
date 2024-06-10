using Microsoft.AspNetCore.Mvc;
using PharmacyApi.Services;

namespace PrzykładowyKolos2.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EventController : ControllerBase
{
    private IEventService _eventService;
    
    public EventController(IEventService eventService)
    {
        _eventService = eventService;
    }
}