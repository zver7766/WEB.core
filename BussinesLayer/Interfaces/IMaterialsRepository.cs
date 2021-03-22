using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entities;

namespace BussinesLayer.Interfaces
{
    public interface IMaterialsRepository
    {
        IEnumerable<Material> GetAllMaterials(bool includeDirectory = false);

        Material GetMaterialById(int materialId, bool includeDirectory = false);
        void SaveMaterial(Material mateiral);
        void DeleteMaterial(Material mateiral);
    }
}
