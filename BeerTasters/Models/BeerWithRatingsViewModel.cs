using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerTasters.Common;

namespace BeerTasters.Models
{
    /// <summary>
    /// NOT going to be used for now
    /// </summary>
    public class BeerWithRatingsViewModel
    {
        public int id;
        public string name;
        public string description;

        List<RatingViewModel> comments;
    }
}
