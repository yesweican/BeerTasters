using BeerTasters.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
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
        public IEnumerable<BeerWithRatingsDTO> Get()
        {
            return data;
        }

        /// <summary>
        /// Return Individual data entry
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET api/BeerRatings/5
        public IEnumerable<BeerWithRatingsDTO> Get(int id)
        {
            ///
            /// To Query the List using the id
            ///

            var rating = data.Where(x => x.id == id);
            return rating;
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
        // PUT api/BeerRatings/5
        public void Put(int id, [FromBody] string value)
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
