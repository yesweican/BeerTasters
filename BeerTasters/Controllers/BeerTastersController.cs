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
    public class BeerTastersController : Controller
    {
        private readonly IPunkRepository _beerRepository;
        private readonly ITasterRepository _beerTasterRepository;

        // GET: BeerTasters
        public async Task<ActionResult> Index()
        {
            //List<BeerWithRatingsDTO> model = new List<BeerWithRatingsDTO>();
            IEnumerable<BeerWithRatingsDTO> model = await _beerTasterRepository.GetRatings();
            //need to populate data here using RESTful API here
            return View("BeerDataView",model);
        }

        // GET: BeerTasters/Edit/5
        public ActionResult Edit(int beerid)
        {
            RatingViewModel model = new RatingViewModel();
            //need to populate data here
            //potentially with viewbag for extra information
            return View("BeerRatingView", model);
        }

        [HttpPost]
        public ActionResult Edit(RatingDTO rating)
        {
            //RatingDTO model = new RatingDTO();
            //need to POST the data to API
            //potentially with viewbag for extra information
            return View();
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
        public ActionResult Punk(int beerid)
        {
            RatingViewModel model = new RatingViewModel();
            //need to populate data here
            //potentially with viewbag for extra information
            return View("BeerRatingView", model);
        }
    }
}