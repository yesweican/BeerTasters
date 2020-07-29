using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerTasters.Common;

namespace BeerTasters.Repository
{
    public interface ITasterRepository
    {
        Task<IEnumerable<BeerWithRatingsDTO>> GetBeerWithRatings();


        Task<BeerWithRatingsDTO> GetBeerWithRatingsById(int id);


        Task<IEnumerable<RatingDTO>> GetRatings();

        Task<bool> SaveRating(RatingDTO dto);
    }
}
