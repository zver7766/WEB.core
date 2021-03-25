using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinesLayer;
using PresentationLayer.Services;

namespace PresentationLayer
{
    public class ServiceManager
    {
        DataManager _dataManager;
        private DirectoryService _directoryService;
        private MaterialService _materialService;

        public ServiceManager(
            DataManager dataManager
        )
        {
            _dataManager = dataManager;
            _directoryService = new DirectoryService(_dataManager);
            _materialService = new MaterialService(_dataManager);
        }
        public DirectoryService Directories { get { return _directoryService; } }
        public MaterialService Materials { get { return _materialService; } }
    }
}
