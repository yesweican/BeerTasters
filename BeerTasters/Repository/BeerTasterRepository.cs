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
    public class BeerTasterRepository:IBeerTasterRepository
    {
        private static readonly HttpClient _client;

        static BeerTasterRepository()
        {
            //_client = HttpClientFactory.Create(handler);
            _client = new HttpClient();
        }

        public async Task<IEnumerable<BeerRatingDTO>> GetRatings()
        {
            var response = await _client.GetAsync(AppSettings.WebApiBaseAddress+"BeerRatings");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<IEnumerable<BeerRatingDTO>>();

            return new List<BeerRatingDTO>();
        }
    }
}