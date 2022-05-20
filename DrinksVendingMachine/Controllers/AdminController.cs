using DrinksVendingMachine.Interfaces;
using DrinksVendingMachine.Interfaces.Services;
using DrinksVendingMachine.Interfaces.Services.Drinks;
using DrinksVendingMachine.Models.DbModels;
using DrinksVendingMachine.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DrinksVendingMachine.Controllers
{
   public class AdminController : Controller
   {
      private readonly IAuthentication Auth;
      private readonly IDrinksService DrinksService;
      private readonly IImageService ImageService;
      private readonly ICoinService CoinService;

      public AdminController(IAuthentication auth, IDrinksService ds, IImageService imgs, ICoinService cs)
      {

         Auth = auth;
         DrinksService = ds;
         ImageService = imgs;
         CoinService = cs;
      }
      // GET: AdminController
      public IActionResult Index(int key)
      {
         if (!Auth.Authenticate(key))
            return RedirectToAction("Index", "Home");
         
         return View(DrinksService.TypesDrinks.GetAll());
      }

      public IActionResult Groups(int id)
      {
         var groups = DrinksService.GroupDrinks.GetByTypeId(id);

         if (groups.FirstOrDefault() == null)
            ViewBag.typeName = DrinksService.TypesDrinks.Get(id).Name;

         ViewBag.typeId = id;

         return PartialView("_Groups", groups);
      }

      public IActionResult Drinks(int id)
      {
         return PartialView("_Drinks", DrinksService.Drinks.GetByGroupId(id));
      }

      public IActionResult Drink(int id)
      {
         DrinkEditViewModel divm = new DrinkEditViewModel() 
         { 
            Drink = DrinksService.Drinks.Get(id), 
            Images = ImageService.GetAll().ToList(), 
         };

         return PartialView("_DrinkForm", divm);
      }

      public IActionResult Images()
      {
         return PartialView("_AddImage", ImageService.GetAll().ToList());
      }

      [HttpPost]
      public async Task<IActionResult> AddImage(IFormFile uploadedFile)
      {
         await ImageService.Add(uploadedFile);

         return PartialView("_AddImage", ImageService.GetAll());
      }

      public IActionResult CreateDrink(int GroupId, string Name)
      {
         var images = ImageService.GetAll().ToList();
         var group = DrinksService.GroupDrinks.Get(GroupId);

         Drink drink = new Drink 
         { 
            Name = Name, 
            DrinkGroup = group, 
            DrinkGroupId = GroupId 
         };

         DrinkEditViewModel divm = new DrinkEditViewModel() 
         { 
            Drink = drink, 
            Images = images 
         };

         return PartialView("_DrinkForm", divm);
      }

      public IActionResult DeleteDrink(int id, int groupId)
      {
         DrinksService.Drinks.Delete(id);

         var drinks = DrinksService.Drinks.GetByGroupId(groupId).ToList();
         if (drinks.Count == 0)
         {
            var group = DrinksService.GroupDrinks.Get(groupId);
            var groups = DrinksService.GroupDrinks.GetByTypeId(group.DrinkTypeId);

            return PartialView("_Groups", groups);
         }
         return PartialView("_Drinks", drinks);
      }

      [HttpPost]
      public IActionResult SaveDrink(Drink model)
      {
         if (ModelState.IsValid)
            DrinksService.Drinks.Save(model);

         return PartialView("_Drinks", DrinksService.Drinks.GetByGroupId(model.DrinkGroupId));
      }

      public void BlockDrink(int id)
      {
         DrinksService.Drinks.Block(id);
      }

      public void BlockCoin(int id)
      {
         CoinService.Block(id);
      }

      public IActionResult Coins()
      {
         return PartialView("_Coins", CoinService.GetAll());
      }

      [HttpGet]
      public IActionResult AddType()
      {
         return PartialView("_AddType");
      }

      [HttpPost]
      public IActionResult AddType(DrinkType model)
      {
         DrinksService.TypesDrinks.Save(model);
         return RedirectToAction("Index");
      }

      [HttpGet]
      public IActionResult DeleteGroup(int id)
      {

         DrinksService.GroupDrinks.Delete(id);
         var drinkTypeId = DrinksService.GroupDrinks.Get(id).DrinkTypeId;
         var groups = DrinksService.GroupDrinks.GetByTypeId(drinkTypeId);
         ViewBag.typeId = drinkTypeId;
         return PartialView("_Groups", groups);
      }

      [HttpPost]
      public IActionResult AddGroup(DrinkGroup model)
      {
         DrinksService.GroupDrinks.Save(model);

         ViewBag.typeId = model.DrinkTypeId;
         return PartialView("_Groups", DrinksService.GroupDrinks.GetByTypeId(model.DrinkTypeId));
      }
   }
}
