using DrinksVendingMachine.Models.DbModels;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DrinksVendingMachine.Interfaces.Services
{
   public interface IImageService
   {
      IEnumerable<Image> GetAll();
      Task Add(IFormFile uploadedFile);
   }

}
