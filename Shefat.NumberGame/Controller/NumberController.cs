using Microsoft.AspNetCore.Mvc;
using Shefat.NumberGame.Services;

namespace Shefat.NumberGame.Controller;

[ApiController]
[Route("api/[controller]")]
public class NumberController : ControllerBase
{
    private readonly INumberService _numberService;

    public NumberController(INumberService numberService)
    {
        _numberService = numberService;
    }

    [HttpPost]
    public async Task<ActionResult<IEnumerable<int>>> NumberGenerator([FromBody] int count)
    {
        if (count < 1 || count > 100)
        {
            return BadRequest("Error! You must choose a number between 1 to 100!");
        }

        var result = await _numberService.GenerateNumbersAsync(count);
        return Ok(result);
    }
    
}