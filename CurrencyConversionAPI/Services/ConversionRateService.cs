using RestSharp;

public class ConversionRateService : IConversionRate
{
    private readonly string _apiKey = "be9f7e44af31a5fc5badad6a";
    private readonly string _baseUrl = "https://v6.exchangerate-api.com/v6/";

    public async Task<decimal> GetConversionRateAsync(string fromCurrency, string toCurrency)
    {
        using var client = new RestClient($"{_baseUrl}{_apiKey}/latest/{fromCurrency}");
        var request = new RestRequest("/", Method.Get);

        var response = await client.ExecuteAsync<ExchangeRateResponse>(request);

        if (response.IsSuccessful && response.Data != null && response.Data.ConversionRates.ContainsKey(toCurrency))
        {
            return response.Data.ConversionRates[toCurrency];
        }

        throw new Exception("Não foi possível obter a taxa de conversão.");
    }
}