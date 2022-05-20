using DrinksVendingMachine.Interfaces.Services;
using DrinksVendingMachine.Models.DbModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace DrinksVendingMachine.Models.Services
{
   public class ImageService : IImageService
   {
      private readonly ApplicationContext Db;
      private readonly IWebHostEnvironment _appEnvironment;
      public ImageService(ApplicationContext context, IWebHostEnvironment appEnvironment)
      {
         Db = context;
         _appEnvironment = appEnvironment;
      }
      public async Task Add(IFormFile uploadedFile)
      {
         if (uploadedFile != null)
         {
            string path = "/Images/" + uploadedFile.FileName;
            using (var fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
            {
               await uploadedFile.CopyToAsync(fileStream);
            }
            Image file = new Image { Name = uploadedFile.FileName, Path = path };
            Db.Images.Add(file);
            Db.SaveChanges();
         }
      }

      public IEnumerable<Image> GetAll()
      {
         return Db.Images;
      }
   }
}
