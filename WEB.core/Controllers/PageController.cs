using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BussinesLayer;
using DataLayer.Enums;
using Microsoft.Extensions.Logging;
using PresentationLayer;
using PresentationLayer.Models;

namespace WEB.core.Controllers
{
    public class PageController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DataManager _dataManager;
        private readonly ServiceManager _serviceManager;
        public PageController(ILogger<HomeController> logger, DataManager dataManager)
        {
            _logger = logger;
            _dataManager = dataManager;
            _serviceManager = new ServiceManager(dataManager);
        }
        public IActionResult Index(int pageId, PageEnums.PageType pageType)
        {
            PageViewModel _viewModel;
            switch (pageType)
            {
                case PageEnums.PageType.Directory:
                    _viewModel = _serviceManager.Directories.DirectoryDBToViewModelById(pageId);
                    break;
                case PageEnums.PageType.Material:
                    _viewModel = _serviceManager.Materials.MaterialDBModelToView(pageId);
                    break;
                default:
                    _viewModel = null;
                    break;

            }

            ViewBag.PageType = pageType;
            return View(_viewModel);
        }

        public IActionResult PageEditor(int pageId, PageEnums.PageType pageType)
        {
            PageEditModel _editModel;
            switch (pageType)
            {
                case PageEnums.PageType.Directory:
                    _editModel = _serviceManager.Directories.GetDirectoryEditModel(pageId);
                    break;
                case PageEnums.PageType.Material:
                    _editModel = _serviceManager.Materials.GetMaterialEditModel(pageId);
                    break;
                default: _editModel = null;
                    break;
               
            }

            ViewBag.PageType = pageType;
            return View(_editModel);
        }
    }
}
