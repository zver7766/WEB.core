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
    public class MaterialService
    {
        private DataManager dataManager;

        public MaterialService(DataManager dataManager)
        {
            this.dataManager = dataManager;
        }

        public MaterialViewModel MaterialDBModelToView(int materialId)
        {
            var _model = new MaterialViewModel()
            {
                Material = dataManager.Materials.GetMaterialById(materialId,true),
            };
            var _dir = dataManager.Directories.GetDirectoryById(_model.Material.DirectoryId);
            if (_dir.Materials.IndexOf(_model.Material) != _dir.Materials.Count())
            {
                _model.NextMaterial = _dir.Materials.ElementAt(_dir.Materials.IndexOf(_model.Material) + 1);
            }

            return _model;
        }

        public DirectoryViewModel SaveMaterialEditModelToDb(DirectoryEditModel directoryEditModel)
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
