namespace DrinksVendingMachine.Models.DbModels
{
   public class Coin
   {
      public int Id { get; set; }
      public int CoinDenomination { get; set; }
      public int Count { get; set; }
      public int SumCoins => CoinDenomination * Count;
      public byte IsBlocked { get; set; }
   }
}
