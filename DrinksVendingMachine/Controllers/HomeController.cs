using DrinksVendingMachine.Interfaces.Services;
using DrinksVendingMachine.Models;
using DrinksVendingMachine.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace DrinksVendingMachine.Controllers
{
   public class HomeController : Controller
   {
      private readonly ILogger<HomeController> _logger;
      private readonly IPurchaseDrinksService PurchaseDrinks;
      public HomeController (ILogger<HomeController> logger, IPurchaseDrinksService ds)
      {
         _logger = logger;
         PurchaseDrinks = ds;
      }

      public IActionResult Index ()
      {
         DrinksBuyViewModel dbvm = new DrinksBuyViewModel 
         { 
            Coins = PurchaseDrinks.GetAllCoins(), 
            Drinks = PurchaseDrinks.GetAllDrinks() 
         };

         return View(dbvm);
      }

      [HttpPost]
      public IActionResult BuyItem(BuyModel model)
      {
         return PartialView("_BuyResult", PurchaseDrinks.Buy(model));
      }

      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error ()
      {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}
