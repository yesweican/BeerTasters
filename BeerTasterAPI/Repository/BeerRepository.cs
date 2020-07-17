using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Net.Http;
using BeerTasters.Common;

namespace BeerTasters.API.Repository
{
    public class BeerRepository:IBeerRepository
    {
        private static readonly HttpClient _client;

        static BeerRepository()
        {
            //_client = HttpClientFactory.Create(handler);
            _client = new HttpClient();
        }

        public async Task<IEnumerable<BeerDTO>> GetBeers()
        {
            var response = await _client.GetAsync(AppSettings.PunkApiBaseAddress + "beers");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<IEnumerable<BeerDTO>>();

            return new List<BeerDTO>();
        }

    }
}