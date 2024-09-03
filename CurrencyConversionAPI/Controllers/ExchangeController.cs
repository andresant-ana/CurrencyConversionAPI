using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class ExchangeController : ControllerBase, IExchangeController
{
    private readonly IConversionRate _conversionRateService;

    public ExchangeController(IConversionRate conversionRateService)
    {
        _conversionRateService = conversionRateService;
    }

    [HttpGet("usd-to-brl")]
    public async Task<IActionResult> GetUsdToBrlRate()
    {
        try
        {
            var rate = await _conversionRateService.GetConversionRateAsync("USD", "BRL");
            return Ok(new { USD_to_BRL = rate });
        }
        catch (Exception ex)
        {
            return StatusCode(500, ex.Message);
        }
    }
}