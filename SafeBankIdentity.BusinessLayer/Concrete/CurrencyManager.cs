using Microsoft.Extensions.Configuration;
using SafeBankIdentity.BusinessLayer.Abstract;
using SafeBankIdentity.DtoLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafeBankIdentity.BusinessLayer.Concrete
{
    public class CurrencyManager : ICurrencyService
    {
        private readonly IConfiguration _configuration;

        public CurrencyManager(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> GetCurrencyValueAsync(CurrencyEnum currency)
        {
            var client = new HttpClient();
            var a = Enum.GetName(typeof(CurrencyEnum), currency);
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri($"https://currency-exchange.p.rapidapi.com/exchange?from={Enum.GetName(typeof(CurrencyEnum), currency)}&to=TRY&q=1.0"),
                Headers = {
                            { "X-RapidAPI-Key", _configuration["RapidAPI:X-RapidAPI-Key"] },
                            { "X-RapidAPI-Host", _configuration["RapidAPI:X-RapidAPI-Host"] },
                          },
            };

            using var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }
    }
}
