using RestSharp;

public interface IConversionRate
{
    Task<decimal> GetConversionRateAsync(string fromCurrency, string toCurrency);
}