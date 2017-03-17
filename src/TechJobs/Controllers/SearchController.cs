using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using TechJobs.Models;

namespace TechJobs.Controllers
{
    public class SearchController : Controller
    {
        private List<Dictionary<string, string>> searchResults;

        public IActionResult Index()
        {
            ViewBag.columns = ListController.columnChoices;
            ViewBag.title = "Search";
            
            return View();
        }

        // TODO #1 - Create a Results action method to process 
        // search request and display results

        public IActionResult Results(string searchType, string searchTerm)

        {           
            //List<Dictionary<string, string>> searchResults=new List<Dictionary<string, string>>();

            // Fetch results
            if (searchType.Equals("all"))
            {
                searchResults = JobData.FindAll();
                ViewBag.jobs = searchResults;
                ViewBag.columns = ListController.columnChoices;
                ViewBag.title = "Search";
                return View("Index");

            }
            else
            {
               searchResults = JobData.FindByColumnAndValue(searchType, searchTerm);
               ViewBag.jobs = searchResults;
               ViewBag.columns = ListController.columnChoices;
               ViewBag.title = "Search";
                return View("Index");
            }

            
            }
        }
    }

