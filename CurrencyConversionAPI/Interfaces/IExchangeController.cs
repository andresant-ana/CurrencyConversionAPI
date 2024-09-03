using Microsoft.AspNetCore.Mvc;

public interface IExchangeController
{
    Task<IActionResult> GetUsdToBrlRate();
}