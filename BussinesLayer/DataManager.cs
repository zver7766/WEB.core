using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinesLayer.Interfaces;

namespace BussinesLayer
{
    public class DataManager
    {
        private IDirectoryRepository _directoryRepository;
        private IMaterialsRepository _materialsRepository;

        public DataManager(IDirectoryRepository directoryRepository, IMaterialsRepository materialsRepository)
        {
            _directoryRepository = directoryRepository;
            _materialsRepository = materialsRepository;
        }

        public IDirectoryRepository Directories
        {
            get { return _directoryRepository; }
        } 
        public IMaterialsRepository Materials
        {
            get { return _materialsRepository; }
        } 

    }
}
