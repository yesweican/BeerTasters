using BeerTasters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeerTasters.Common;
using System.Threading.Tasks;
using BeerTasters.Repository;

namespace BeerTasters.Controllers
{
    public class BeersController : Controller
    {
        private readonly IPunkRepository _beerRepository;
        private readonly ITasterRepository _beerTasterRepository;

        public BeersController()
        {
            _beerTasterRepository = new TasterRepository();
            _beerRepository = new PunkRepository();
        }

        // GET: BeerTasters
        public async Task<ActionResult> Index()
        {
            IEnumerable<BeerWithRatingsDTO> model = await _beerTasterRepository.GetBeerWithRatings();
            //need to populate data here using RESTful API here
            return View("BeerDataView",model);
        }

        // GET: BeerTasters/Details/5
        public ActionResult Review(int beerid)
        {
            RatingDTO model = new RatingDTO();
            model.beerid = beerid;
            return View("BeerRatingView", model);
        }

        // GET: BeerTasters/Details/5
        public ActionResult Details(int beerid)
        {
            BeerWithRatingsDTO model = new BeerWithRatingsDTO();
            //need to populate data here
            //potentially with viewbag for extra information
            return View("BeerDataEntryView", model);
        }

        // GET: BeerTasters/Punk
        public async Task<ActionResult> Punk()
        {
            var repo = new PunkRepository();
            var model = await repo.GetBeers();
            //need to populate data here
            //potentially with viewbag for extra information
            return View("PunkView", model);
        }
    }
}