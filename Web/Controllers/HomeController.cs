using Core.Entites;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.ViewModels;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUnitOfWork<Owner> _owner;
        private readonly IUnitOfWork<PortfolioItem> _portoflio;
        private readonly IUnitOfWork<MoServices> _moservices;

        public HomeController(IUnitOfWork<Owner> owner,IUnitOfWork<PortfolioItem> portoflio,IUnitOfWork<MoServices> moservices)
        {
            _owner = owner;
            _portoflio = portoflio;
            _moservices = moservices;
        }
        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                Owner = _owner.Entity.GetAll().First(),
                PortoflioItems = _portoflio.Entity.GetAll().ToList(),
                MoServices = _moservices.Entity.GetAll().ToList()

            };
            return View(homeViewModel);
        }
    }
}
