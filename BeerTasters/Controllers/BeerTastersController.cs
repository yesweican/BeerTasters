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
        public async Task<ActionResult> Edit(RatingDTO rating)
        {
            var repo = new TasterRepository();
            //need to POST the data to API
            await repo.SaveRating(rating);
            //potentially with viewbag for extra information
            return RedirectToAction("Index"); ;
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