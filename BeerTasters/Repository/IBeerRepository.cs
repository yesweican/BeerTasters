﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BeerTasters.Common;

namespace BeerTasters.Repository
{
    public interface IBeerRepository
    {
        Task<IEnumerable<BeerDTO>> GetBeers();
    }
}
