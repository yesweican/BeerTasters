using BeerTasters.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace BeerTasters.API.Controllers
{
    public class BeerWithRatingsController : ApiController
    {
        static List<BeerWithRatingsDTO> data;

        static BeerWithRatingsController()
        {
            ReloadDataFromFile();
        }


        public static void ReloadDataFromFile()
        {
            if (File.Exists("data.json"))
            {
                //load from the existing data
                string dataString = File.ReadAllText(@"C:\Data\data.json");
                data = JsonConvert.DeserializeObject<List<BeerWithRatingsDTO>>(dataString);
            }
            else
            {
                //creating empty collection of data
                data = new List<BeerWithRatingsDTO>();
                //persist the data - need lock
                string newString = JsonConvert.SerializeObject(data, Formatting.Indented);
                File.WriteAllText("data.json", newString);
            }
        }

        public BeerWithRatingsController()
        {
            return;
        }

        /// <summary>
        /// Return ALL data Entries
        /// </summary>
        /// <returns></returns>
        // GET api/BeerRatings
        [HttpGet]
        [Route("api/BeerWithRatings")]
        public IEnumerable<BeerWithRatingsDTO> Index(string name = null)
        {
            if (string.IsNullOrEmpty(name))
                return data;
            else
                return data.Where(x => x.name == name);
        }

        /// <summary>
        /// Return Individual data entry
        /// </summary>
        /// <param name="id">beerid</param>
        /// <returns></returns>
        // GET api/BeerRatings/5
        public BeerWithRatingsDTO Get(int id)
        {
            ///
            /// To Query the List using the id
            ///

            var beerWithRatings = data.Where(x => x.id == id).FirstOrDefault();
            return beerWithRatings;
        }


        /// <summary>
        /// Update + Creating NEW
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // Post api/BeerWithRatings
        [HttpPost]
        public void SaveBeer([FromBody] BeerWithRatingsDTO dto)
        {
            ///
            /// Load the string to RatingDTO
            /// To Query the List using the id
            /// If Found update, if not Insert
            ///
        }

        // DELETE api/BeerRatings/5
        public void Delete(int id)
        {
        }
    }
}
