using System;
using System.Collections.Generic;
using System.Text;
using DataLayer.Entities;

namespace BussinesLayer.Interfaces
{
    public interface IDirectoryRepository
    {
        IEnumerable<Directory> GetAllDirectories(bool includeMaterials = false);

        Directory GetDirectoryById(int directoryId, bool includeMaterials = false);
        void SaveDirectory(Directory directory);
        void DeleteDirectory(Directory directory);
    }
}
