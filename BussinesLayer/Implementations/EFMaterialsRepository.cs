using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BussinesLayer.Interfaces;
using DataLayer;
using DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BussinesLayer.Implementations
{
    public class EFMaterialsRepository : IMaterialsRepository
    {
        private EFDBContext context;

        public EFMaterialsRepository(EFDBContext context)
        {
            this.context = context;
        }

        public IEnumerable<Material> GetAllMaterials(bool includeDirectory = false)
        {
            if (includeDirectory)
                return context.Set<Material>().Include(x => x.Directory).AsNoTracking().ToList();
            else
                return context.Material.ToList();
        }

        public Material GetMaterialById(int materialId, bool includeDirectory = false)
        {
            if (includeDirectory)
                return context.Set<Material>().Include(x => x.Directory).AsNoTracking()
                    .FirstOrDefault(x => x.Id == materialId);
            else
                return context.Material.FirstOrDefault(x => x.Id == materialId);
        }

        public void SaveMaterial(Material mateiral)
        {
            if (mateiral.Id == 0)
                context.Material.Add(mateiral);
            else
                context.Entry(mateiral).State = EntityState.Modified;
            context.SaveChangesAsync();
        }

        public void DeleteMaterial(Material mateiral)
        {
            context.Material.Remove(mateiral);
            context.SaveChangesAsync();
        }
    }
}
