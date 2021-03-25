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
            if (_dir.Materials.IndexOf(_model.Material) != _dir.Materials.Count()-1)
            {
                _model.NextMaterial = _dir.Materials.ElementAt(_dir.Materials.IndexOf(_model.Material) + 1);
            }

            return _model;
        }

        public MaterialEditModel GetMaterialEditModel(int materialId)
        {
            var _dbModel = dataManager.Materials.GetMaterialById(materialId);
            var _editModel = new MaterialEditModel()
            {
                Id = _dbModel.Id = _dbModel.Id,
                DirectoryId = _dbModel.DirectoryId,
                Title = _dbModel.Title,
                Html = _dbModel.Html,
            };
            return _editModel;
        }

        public MaterialViewModel SaveMaterialEditModelToDb(MaterialEditModel editModel)
        {
            Material material;
            if (editModel.Id != 0)
            {
                material = dataManager.Materials.GetMaterialById(editModel.Id);
            }
            else
            {
                material = new Material();
            }

            material.Title = editModel.Title;
            material.Html = editModel.Html;
            material.DirectoryId = editModel.DirectoryId;
            dataManager.Materials.SaveMaterial(material);
            return MaterialDBModelToView(material.Id);
        }
        
    }
}
