using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Net;
using System.Net.Http;
using BeerTasters.Common;

namespace BeerTasters.Repository
{
    public class PunkRepository:IPunkRepository
    {
        private static readonly HttpClient _client;

        static PunkRepository()
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

        public async Task<BeerDTO> GetBeersById(int id)
        {
            var response = await _client.GetAsync(AppSettings.PunkApiBaseAddress + "beers/" + id);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<BeerDTO>();

            return null;
        }

    }
}