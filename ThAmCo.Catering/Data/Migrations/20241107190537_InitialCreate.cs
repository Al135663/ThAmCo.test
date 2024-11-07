using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ThAmCo.Catering.Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FoodItems",
                columns: new[] { "FoodItemId", "Description", "UnitPrice" },
                values: new object[,]
                {
                    { 1, "Spaghetti Carbonara", 12.99m },
                    { 2, "Caesar Salad", 8.99m },
                    { 3, "Grilled Veggie Skewers", 10.50m },
                    { 4, "BBQ Ribs", 15.99m },
                    { 5, "Garlic Bread", 4.99m }
                });

            migrationBuilder.InsertData(
                table: "Menus",
                columns: new[] { "MenuId", "MenuName" },
                values: new object[,]
                {
                    { 1, "Italian Feast" },
                    { 2, "Vegetarian Delight" },
                    { 3, "BBQ Extravaganza" }
                });

            migrationBuilder.InsertData(
                table: "FoodBookings",
                columns: new[] { "FoodBookinId", "ClientReferenceId", "MenuId", "NumberOfGuests" },
                values: new object[,]
                {
                    { 1, 101, 1, 20 },
                    { 2, 102, 2, 15 },
                    { 3, 103, 3, 50 }
                });

            migrationBuilder.InsertData(
                table: "MenuFoodItems",
                columns: new[] { "FoodItemId", "MenuId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 5, 1 },
                    { 2, 2 },
                    { 3, 2 },
                    { 4, 3 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FoodBookings",
                keyColumn: "FoodBookinId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FoodBookings",
                keyColumn: "FoodBookinId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FoodBookings",
                keyColumn: "FoodBookinId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MenuFoodItems",
                keyColumns: new[] { "FoodItemId", "MenuId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "MenuFoodItems",
                keyColumns: new[] { "FoodItemId", "MenuId" },
                keyValues: new object[] { 5, 1 });

            migrationBuilder.DeleteData(
                table: "MenuFoodItems",
                keyColumns: new[] { "FoodItemId", "MenuId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "MenuFoodItems",
                keyColumns: new[] { "FoodItemId", "MenuId" },
                keyValues: new object[] { 3, 2 });

            migrationBuilder.DeleteData(
                table: "MenuFoodItems",
                keyColumns: new[] { "FoodItemId", "MenuId" },
                keyValues: new object[] { 4, 3 });

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "FoodItems",
                keyColumn: "FoodItemId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Menus",
                keyColumn: "MenuId",
                keyValue: 3);
        }
    }
}
