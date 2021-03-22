using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer.Entities;

namespace DataLayer
{
    public static class SampleData
    {
        public static void InitData(EFDBContext context)
        {
            if (!context.Directory.Any())
            {
                context.Directory.Add(new Directory() {Title = "First Directory", Html = "<b>Directory Content</b>"});
                context.Directory.Add(new Directory() {Title = "Second Directory", Html = "<b>Directory Content</b>"});
                context.SaveChangesAsync();
                context.Material.Add(new Material() { Title = "First Material", Html = "<i>Material Content</i>", DirectoryId = context.Directory.First().Id });
                context.Material.Add(new Material() { Title = "Second Material", Html = "<i>Material Content</i>", DirectoryId = context.Directory.First(p => p.Title == "Second Directory").Id});
                context.Material.Add(new Material() { Title = "Third Material", Html = "<i>Material Content</i>", DirectoryId = context.Directory.First(p => p.Title == "Second Directory").Id });
                context.SaveChangesAsync();
            }

        //    if (!context.Material.Any())
        //    {
        //        context.Material.Add(new Material() { Title = "First Material", Html = "<i>Material Content</i>", DirectoryId = context.Directory.First().Id });
        //        context.Material.Add(new Material() { Title = "Second Material", Html = "<i>Material Content</i>", DirectoryId = context.Directory.First(p => p.Title == "Second Directory").Id });
        //        context.Material.Add(new Material() { Title = "Third Material", Html = "<i>Material Content</i>", DirectoryId = context.Directory.First(p => p.Title == "Second Directory").Id });
        //        context.SaveChangesAsync();
        //    }
        }
    }
}
