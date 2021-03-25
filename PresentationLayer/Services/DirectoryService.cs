using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinesLayer;
using DataLayer.Entities;
using PresentationLayer.Models;

namespace PresentationLayer.Services
{
    public class DirectoryService
    {
        private DataManager dataManager;
        private MaterialService materialService;
        public DirectoryService(DataManager dataManager, MaterialService materialService)
        {
            this.dataManager = dataManager;
            this.materialService = materialService;
        }

        public List<DirectoryViewModel> GetDirectoriesList()
        {
            var _dirs = dataManager.Directories.GetAllDirectories();
            List<DirectoryViewModel> _modelList = new List<DirectoryViewModel>();
            foreach (var item in _dirs)
            {
                _modelList.Add(DirectoryDBToViewModelById(item.Id));
            }

            return _modelList;
        }

        private DirectoryViewModel DirectoryDBToViewModelById(int directoryId)
        {
            var _directory = dataManager.Directories.GetDirectoryById(directoryId, true);

            List<MaterialViewModel> _materialViewModelList = new List<MaterialViewModel>();
            foreach (var item in _directory.Materials)
            {
             _materialViewModelList.Add(materialService.MaterialDBModelToView(item.Id));   
            }

            return new DirectoryViewModel() {Directory = _directory, Materials = _materialViewModelList};
        }

        public DirectoryEditModel GetDirectoryEditModel(int directoryId = 0)
        {
            if (directoryId != 0)
            {
                var _dirDB = dataManager.Directories.GetDirectoryById(directoryId);
                var _dirEditModel = new DirectoryEditModel()
                {
                    Id= _dirDB.Id,
                    Title = _dirDB.Title,
                    Html = _dirDB.Html
                };
                return _dirEditModel;
            }
            else
            {
                return new DirectoryEditModel() { };
            }
        }

        public DirectoryViewModel SaveDirectoryEditModelToDb(DirectoryEditModel directoryEditModel)
        {
            Directory _directoryDbModel;
            if (directoryEditModel.Id != 0)
            {
                _directoryDbModel = dataManager.Directories.GetDirectoryById(directoryEditModel.Id);
            }
            else
            {
                _directoryDbModel = new Directory();
            }
            _directoryDbModel.Title = directoryEditModel.Title;
            _directoryDbModel.Html = directoryEditModel.Html;

            dataManager.Directories.SaveDirectory(_directoryDbModel);

            return DirectoryDBToViewModelById(_directoryDbModel.Id);
            //var _directory = directoryEditModel;
            //dataManager.Directories.SaveDirectory(_directory);
            //directoryViewModel.Directory = _directory;
            //return directoryViewModel;
        }
    }
}
