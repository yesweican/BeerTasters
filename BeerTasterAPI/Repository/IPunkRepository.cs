using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerTasters.Common;

namespace BeerTasters.API.Repository
{
    interface IPunkRepository
    {
        Task<IEnumerable<BeerDTO>> GetBeers();

        Task<BeerDTO> GetBeersById(int id);
    }
}
