namespace DrinksVendingMachine.Models.DbModels
{
   public class Drink
   {
      public int Id { get; set; }
      public string Name { get; set; }
      public string Description { get; set; }
      public decimal Volume { get; set; }
      public int Price { get; set; }
      public int Count { get; set; }
      public byte IsBlocked { get; set; }
      public int DrinkGroupId { get; set; }
      public DrinkGroup DrinkGroup { get; set; }
      public string ImageUrl { get; set; }
   }
}
