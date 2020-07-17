using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerTasters.Common
{
    public class BeerDTO
    {
        public int id;
        public string name;
        public string tagline;
        public string description;
        public string image_url;
        public float? abv;
        public float? ibu;
        public float? target_fg;
        public float? target_og;
        public float? ebc;
        public float? srm;
        public float? ph;
    }
}
