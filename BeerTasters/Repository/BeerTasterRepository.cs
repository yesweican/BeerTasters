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

        public async Task<IEnumerable<BeerDataEntryDTO>> GetRatings()
        {
            var response = await _client.GetAsync(AppSettings.WebApiBaseAddress+"BeerRatings");
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<IEnumerable<BeerDataEntryDTO>>();

            return new List<BeerDataEntryDTO>();
        }

        public async Task<BeerDataEntryDTO> GetRatingsById(int id)
        {
            var response = await _client.GetAsync(AppSettings.WebApiBaseAddress + "BeerRatings/"+id);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadAsAsync<BeerDataEntryDTO>();

            return null;
        }

        public async Task<bool> SaveRating(BeerRatingDTO dto)
        {
            var response = await _client.PutAsJsonAsync<BeerRatingDTO>(AppSettings.WebApiBaseAddress + "BeerRatings", dto);
            if (response.IsSuccessStatusCode)
                return true;

            return false;
        }
    }
}