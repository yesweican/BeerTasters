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
    public class TasterRepository:ITasterRepository
    {
        private static readonly HttpClient _client;

        static TasterRepository()
        {
            //_client = HttpClientFactory.Create(handler);
            _client = new HttpClient();
        }

        public async Task<IEnumerable<BeerWithRatingsDTO>> GetRatings()
        {
            var response = await _client.GetAsync(AppSettings.WebApiBaseAddress+"BeerWithRatings");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<IEnumerable<BeerWithRatingsDTO>>();

            return new List<BeerWithRatingsDTO>();
        }

        public async Task<BeerWithRatingsDTO> GetRatingsById(int id)
        {
            var response = await _client.GetAsync(AppSettings.WebApiBaseAddress + "BeerWithRatings/"+id);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<BeerWithRatingsDTO>();

            return null;
        }

        public async Task<bool> SaveRating(RatingDTO dto)
        {
            var response = await _client.PutAsJsonAsync<RatingDTO>(AppSettings.WebApiBaseAddress + "Ratings", dto);
            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }
    }
}