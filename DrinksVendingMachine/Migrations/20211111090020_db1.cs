using Microsoft.EntityFrameworkCore.Migrations;

namespace DrinksVendingMachine.Migrations
{
    public partial class db1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
         migrationBuilder.DropTable(
             name: "Coins");

         migrationBuilder.DropTable(
             name: "Drinks");

         migrationBuilder.DropTable(
             name: "Images");

         migrationBuilder.DropTable(
             name: "DrinkGroups");

         migrationBuilder.DropTable(
             name: "DrinkTypes");
         migrationBuilder.CreateTable(
                name: "Coins",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CoinDenomination = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    IsBlocked = table.Column<byte>(type: "tinyint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Coins", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrinkTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Path = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DrinkGroups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DrinkTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DrinkGroups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DrinkGroups_DrinkTypes_DrinkTypeId",
                        column: x => x.DrinkTypeId,
                        principalTable: "DrinkTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Drinks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Volume = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Count = table.Column<int>(type: "int", nullable: false),
                    IsBlocked = table.Column<byte>(type: "tinyint", nullable: false),
                    DrinkGroupId = table.Column<int>(type: "int", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drinks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Drinks_DrinkGroups_DrinkGroupId",
                        column: x => x.DrinkGroupId,
                        principalTable: "DrinkGroups",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DrinkGroups_DrinkTypeId",
                table: "DrinkGroups",
                column: "DrinkTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Drinks_DrinkGroupId",
                table: "Drinks",
                column: "DrinkGroupId");

            migrationBuilder.InsertData(
               table: "DrinkTypes",
               columns: new[] { "Id", "Name", "Description" },
               values: new object[,] 
               {
                  { 1, "Газированая вода", "Coca-Cola, Pepsi, Fanta ..." },
                  { 2, "Соки", "J7, Rich ..." },
               });

            migrationBuilder.InsertData(
               table: "DrinkGroups",
               columns: new[] { "Id", "Name", "DrinkTypeId" },
               values: new object[,]
               {
                  { 1, "Coca-Cola", 1 },
                  { 2, "Fanta", 1 },
                  { 3, "Sprite", 1 },
                  { 4, "7Up", 1 },
                  { 5, "Pepsi", 1 },
                  { 6, "J7", 2 },
                  { 7, "Rich", 2 },
               });

            migrationBuilder.InsertData(
               table: "Coins",
               columns: new[] { "CoinDenomination", "Count", "IsBlocked" },
               values: new object[,]
               {
                  { 1, 10, 0 },
                  { 2, 10, 0 },
                  { 5, 10, 0 },
                  { 10, 10, 0 },
               });

      }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DropTable(
            //    name: "Coins");

            //migrationBuilder.DropTable(
            //    name: "Drinks");

            //migrationBuilder.DropTable(
            //    name: "Images");

            //migrationBuilder.DropTable(
            //    name: "DrinkGroups");

            //migrationBuilder.DropTable(
            //    name: "DrinkTypes");
        }
    }
}
