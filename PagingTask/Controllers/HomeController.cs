using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PagingTask.Models;
using PagingTask.Models.ViewModels;
using PagingTask.Infrastructure;

namespace PagingTask.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private static List<Organization> organizations = OrganizationGenerator.OrganizationList(100);
        //public int pageSize = 10;
        //public int rangePages = 3;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            //organizations = new OrganizationGenerator().OrganizationList(100);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Organizations(int pageNumber = 1, int rangePages = 3, int pageSize = 10)
        
        {



            var pagedOrganizations = organizations.OrderBy(o => o.Name).Skip((pageNumber - 1) * pageSize).Take(pageSize);

            return View(new OrganizationListViewModel { Organizations= organizations.OrderBy(o => o.Name)
                                                                                    .Skip((pageNumber - 1) * pageSize)
                                                                                    .Take(pageSize),
                                                        PagingInfo = new PagingInfo { CurrentPage =pageNumber, ItemsPerPage=pageSize, TotalItems=organizations.Count, RangePages=rangePages}
        });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
