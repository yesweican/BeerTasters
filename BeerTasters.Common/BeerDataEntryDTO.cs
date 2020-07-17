using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeerTasters.Common
{
    public class BeerDataEntryDTO
    {
        public int id;
        public string name;
        public string description;

        public List<RatingDTO> comments;
    }
}
