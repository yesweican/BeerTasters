using BeerTasters.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BeerTasters.Common;
using BeerTasters.Repository;

namespace BeerTasters.Controllers
{
    public class BeerTastersController : Controller
    {
        private readonly IBeerRepository _beerRepository;
        private readonly IBeerTasterRepository _beerTasterRepository;

        // GET: BeerTasters
        public ActionResult Index()
        {
            BeerDataEntryViewModel model = new BeerDataEntryViewModel();
            //need to populate data here using RESTful API here
            return View("BeerDataView",model);
        }

        // GET: BeerTasters/Edit/5
        public ActionResult Edit(int beerid)
        {
            BeerRatingViewModel model = new BeerRatingViewModel();
            //need to populate data here
            //potentially with viewbag for extra information
            return View("BeerRatingView", model);
        }

        // GET: BeerTasters/Details/5
        public ActionResult Details(int beerid)
        {
            BeerDataEntryDTO model = new BeerDataEntryDTO();
            //need to populate data here
            //potentially with viewbag for extra information
            return View("BeerDataEntryView", model);
        }

        // GET: BeerTasters/Punk
        public ActionResult Punk(int beerid)
        {
            BeerRatingViewModel model = new BeerRatingViewModel();
            //need to populate data here
            //potentially with viewbag for extra information
            return View("BeerRatingView", model);
        }
    }
}