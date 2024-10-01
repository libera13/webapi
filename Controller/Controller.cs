using Microsoft.AspNetCore.Mvc;
using webapi.Service;
using webapi.Models;

[Route("api/controller")]
[ApiController]
public class MyDataController : ControllerBase
{
    private readonly Service _myDataService;

    public MyDataController(Service myDataService)
    {
        _myDataService = myDataService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Model>>> Get()
    {
        var data = await _myDataService.GetAllAsync();
        return Ok(data);
    }
}