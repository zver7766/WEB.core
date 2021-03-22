using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entities;

namespace BussinesLayer.Interfaces
{
    public interface IMaterialsRepository
    {
        IEnumerable<Material> GetAllDirectories(bool includeDirectory = false);

        Material GetMaterialById(int directoryId, bool includeDirectory = false);
        void SaveMaterial(Material mateiral);
        void DeleteMaterial(Material mateiral);
    }
}
