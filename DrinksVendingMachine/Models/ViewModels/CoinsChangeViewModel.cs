namespace DrinksVendingMachine.Models.ViewModels
{
   public class CoinsChangeViewModel
   {
      public int CoinDen { get; set; }
      public int CoinCount { get; set; }
      public int CoinSum => CoinDen * CoinCount;
   }
}
