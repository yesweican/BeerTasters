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

namespace BeerTasters.API.Controllers
{
    public class BeerWithRatingsController : ApiController
    {
        static List<BeerWithRatingsDTO> data;

        static BeerWithRatingsController()
        {
            if(File.Exists("data.json"))
            {
                //load from the existing data
                string dataString = File.ReadAllText("data.json");
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
        /// <summary>
        /// Return ALL data Entries
        /// </summary>
        /// <returns></returns>
        // GET api/BeerRatings
        public IEnumerable<BeerWithRatingsDTO> Get(string name = null)
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

        // POST api/BeerRatings
        //public void Post([FromBody] string value)
        //{
        //}

        /// <summary>
        /// Update + Creating NEW
        /// </summary>
        /// <param name="id"></param>
        /// <param name="value"></param>
        // PUT api/BeerWithRatings/5
        [HttpPost]
        public void Put([FromBody] BeerWithRatingsDTO dto)
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
