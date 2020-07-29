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

        public async Task<IEnumerable<BeerWithRatingsDTO>> GetBeerWithRatings()
        {
            string url = AppSettings.WebApiBaseAddress+"BeerWithRatings";
            var response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<IEnumerable<BeerWithRatingsDTO>>();

            return new List<BeerWithRatingsDTO>();
        }

        public async Task<BeerWithRatingsDTO> GetBeerWithRatingsById(int id)
        {
            string url = AppSettings.WebApiBaseAddress + "BeerWithRatings/" + id;
            var response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<BeerWithRatingsDTO>();

            return null;
        }

        public async Task<IEnumerable<RatingDTO>> GetRatings()
        {
            string url = AppSettings.WebApiBaseAddress + "Ratings";
            var response = await _client.GetAsync(url);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<IEnumerable<RatingDTO>>();

            return new List<RatingDTO>();
        }

        public async Task<bool> SaveRating(RatingDTO dto)
        {
            var response = await _client.PutAsJsonAsync<RatingDTO>(AppSettings.WebApiBaseAddress + "Ratings/SaveRating", dto);
            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }
    }
}