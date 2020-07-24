using BeerTasters.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace BeerTasters.API.Controllers
{
    public class RatingController : ApiController
    {
        static List<BeerWithRatingsDTO> data;

        static RatingController()
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
        public IEnumerable<RatingDTO> Get(string name=null)
        {
            List<RatingDTO> result = new List<RatingDTO>();

            foreach(var v in data)
            {
                if(string.IsNullOrEmpty(name)||v.name==name)
                {
                    foreach(var c in v.comments)
                    {
                        RatingDTO dto = new RatingDTO();

                        dto.beerid = v.id;
                        dto.username = c.username;
                        dto.userrating = c.userrating;
                        dto.comment = c.comment;

                        result.Add(dto);
                    }
                }
            }    

            return result;
        }

        // PUT api/Ratings/
        [HttpPost]
        public void Post([FromBody] RatingDTO dto)
        {
            ///
            /// Load the string to RatingDTO
            /// To Query the List using the id
            /// If Found update, if not Insert
            ///
            var row = data.Where(x => x.id == dto.beerid).FirstOrDefault();

            if(row==null)
            {
                BeerWithRatingsDTO temp = new BeerWithRatingsDTO();
                temp.comments.Add(new RatingShortDTO() { username = dto.username, userrating = dto.userrating, comment = dto.comment });

                data.Add(temp);
            }
            else ////row!=null
            {
                var comment = row.comments.Where(x => x.username == dto.username).FirstOrDefault();

                if (comment == null)
                    row.comments.Add(new RatingShortDTO() { username = dto.username, userrating = dto.userrating, comment = dto.comment });
                else
                {
                    comment.username = dto.username;
                    comment.userrating = dto.userrating;
                    comment.comment = dto.comment;
                }
            }

            //persist the data back into File
            string newString = JsonConvert.SerializeObject(data, Formatting.Indented);
            File.WriteAllText("data.json", newString);

        }

    }
}