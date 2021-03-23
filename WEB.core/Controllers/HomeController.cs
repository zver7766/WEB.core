using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BussinesLayer;
using BussinesLayer.Interfaces;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;
using WEB.core.Models;

namespace WEB.core.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private readonly EFDBContext _context;
        //private readonly IDirectoryRepository _diRep;
        private readonly DataManager _dataManager;
        public HomeController(/*EFDBContext context, IDirectoryRepository dirRep, */ILogger<HomeController> logger, DataManager dataManager)
        {
            //_context = context;
            //_diRep = dirRep;
            _logger = logger;
            _dataManager = dataManager;
        }

        public IActionResult Index()
        {
            //List<Directory> _dirs = _context.Directory.Include(x => x.Materials).ToList();
            //List<Directory> _dirs = _dataManager.Directories;
            List<Directory> _dirs = _dataManager.Directories.GetAllDirectories(true).ToList();
            return View(_dirs);;
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
