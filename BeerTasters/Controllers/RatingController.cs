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
    public class RatingController : Controller
    {
        private readonly IPunkRepository _beerRepository;
        private readonly ITasterRepository _beerTasterRepository;

        public RatingController()
        {
            _beerTasterRepository = new TasterRepository();
            _beerRepository = new PunkRepository();
        }

        // GET: BeerTasters
        public ActionResult Index()
        {
            return View();
        }

        // GET: BeerTasters/Edit/5
        public ActionResult Create()
        {
            RatingDTO model = new RatingDTO();
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
    }
}