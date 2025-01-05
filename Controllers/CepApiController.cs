using CepApi.Features.Cep.Models;
using CepApi.Features.Cep.Services;

namespace CepApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CepApiController(ICepApiService cepApiService, ILogger<CepApiController> logger) : ControllerBase
{
    [HttpGet("/cep")]
    public async Task<IActionResult> GetApi([FromQuery] CepInput input)
    {
        try
        {
            var getCep = await cepApiService.GetCepAsync(input);

            logger.LogInformation($"Success in {nameof(CepApiController)}");
            return Ok(getCep);
        }
        catch(Exception ex)
        {
            logger.LogError($"No success in {nameof(CepApiController)} - {ex.Message}");
            return BadRequest();
        }
    }
}
