using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CoinbasePro.Core.Dto.Integration;
using CoinbasePro.Core.Integration;
using Hub.Web.Http;

namespace CoinbasePro.Integration
{
    public class CoinbaseApiConnector : HttpClientService, ICoinbaseApiConnector
    {
        private const string ExchangeRatePath = "/api/exchangerates/exchangerate";
        private const string ExchangeRatesPath = "/api/exchangerates/exchangerates";
        
        public CoinbaseApiConnector(HttpClient httpClient) : base(httpClient, "CoinbaseApi") {}
        
        public async Task<Response<IList<ExchangeRateDto>>> GetExchangeRates()
        {
            return await Get<IList<ExchangeRateDto>>(ExchangeRatesPath);
        }

        public async Task<Response<ExchangeRateDto>> GetExchangeRate(string currency)
        {
            return await Get<ExchangeRateDto>(ExchangeRatePath, $"currency={currency}");
        }
    }
}