using CombinationsLib;
using CombinationsUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CombinationsUI.Controllers
{
    public class CombinationsController : Controller
    {
        CombinationsRepo repo = new CombinationsRepo();

        // GET: Combinations
        public ActionResult Index()
        {
            IEnumerable<GroupByDigitCount> solutionSets = repo.GetSolutionSets();
            return View(solutionSets);
        }
    }
}