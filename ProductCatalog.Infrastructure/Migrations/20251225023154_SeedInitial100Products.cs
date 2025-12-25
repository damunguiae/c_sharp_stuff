using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductCatalog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitial100Products : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CreatedAt", "Description", "ImageUrl", "Name", "Price", "Rating", "StockQuantity", "UpdatedAt" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality toys product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+1", "Classic Toys Product 1", 122.97m, 1, 261, null },
                    { 2, new DateTime(2024, 4, 3, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality toys product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+2", "Deluxe Toys Product 2", 166.29m, 2, 380, null },
                    { 3, new DateTime(2024, 1, 13, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality sports product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+3", "Modern Sports Product 3", 352.87m, 3, 130, null },
                    { 4, new DateTime(2024, 9, 14, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality food product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+4", "Deluxe Food Product 4", 367.72m, 1, 76, null },
                    { 5, new DateTime(2024, 11, 26, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality food product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+5", "Deluxe Food Product 5", 49.73m, 1, 355, null },
                    { 6, new DateTime(2024, 7, 31, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality toys product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+6", "Deluxe Toys Product 6", 177.74m, 2, 20, null },
                    { 7, new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality food product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+7", "Premium Food Product 7", 492.15m, 4, 402, null },
                    { 8, new DateTime(2024, 2, 12, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality clothing product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+8", "Premium Clothing Product 8", 55.91m, 4, 390, null },
                    { 9, new DateTime(2024, 1, 17, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality clothing product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+9", "Pro Clothing Product 9", 270.65m, 1, 324, null },
                    { 10, new DateTime(2024, 8, 17, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality sports product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+10", "Deluxe Sports Product 10", 55.72m, 4, 210, null },
                    { 11, new DateTime(2024, 9, 19, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality clothing product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+11", "Premium Clothing Product 11", 338.65m, 1, 133, null },
                    { 12, new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality electronics product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+12", "Vintage Electronics Product 12", 20.83m, 3, 398, null },
                    { 13, new DateTime(2024, 1, 24, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality home product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+13", "Premium Home Product 13", 755.95m, 1, 6, null },
                    { 14, new DateTime(2024, 5, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality toys product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+14", "Premium Toys Product 14", 832.16m, 3, 464, null },
                    { 15, new DateTime(2024, 10, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality sports product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+15", "Premium Sports Product 15", 345.49m, 3, 70, null },
                    { 16, new DateTime(2024, 9, 25, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality sports product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+16", "Vintage Sports Product 16", 277.64m, 3, 453, null },
                    { 17, new DateTime(2024, 2, 29, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality electronics product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+17", "Smart Electronics Product 17", 871.91m, 4, 166, null },
                    { 18, new DateTime(2024, 2, 19, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality electronics product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+18", "Vintage Electronics Product 18", 309.92m, 1, 388, null },
                    { 19, new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality clothing product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+19", "Deluxe Clothing Product 19", 471.56m, 4, 493, null },
                    { 20, new DateTime(2024, 1, 9, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality toys product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+20", "Modern Toys Product 20", 506.85m, 4, 494, null },
                    { 21, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality books product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+21", "Smart Books Product 21", 34.43m, 2, 109, null },
                    { 22, new DateTime(2024, 2, 14, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality clothing product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+22", "Deluxe Clothing Product 22", 389.99m, 5, 46, null },
                    { 23, new DateTime(2024, 1, 4, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality electronics product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+23", "Modern Electronics Product 23", 301.46m, 5, 375, null },
                    { 24, new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality electronics product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+24", "Pro Electronics Product 24", 816.31m, 5, 119, null },
                    { 25, new DateTime(2024, 4, 18, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality books product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+25", "Deluxe Books Product 25", 581.03m, 1, 312, null },
                    { 26, new DateTime(2024, 10, 12, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality clothing product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+26", "Premium Clothing Product 26", 217.76m, 5, 466, null },
                    { 27, new DateTime(2024, 7, 22, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality clothing product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+27", "Smart Clothing Product 27", 178.04m, 3, 147, null },
                    { 28, new DateTime(2024, 6, 11, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality toys product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+28", "Premium Toys Product 28", 548.36m, 5, 195, null },
                    { 29, new DateTime(2024, 10, 22, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality books product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+29", "Smart Books Product 29", 427.28m, 5, 271, null },
                    { 30, new DateTime(2024, 9, 19, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality clothing product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+30", "Premium Clothing Product 30", 12.56m, 5, 90, null },
                    { 31, new DateTime(2024, 12, 17, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality home product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+31", "Deluxe Home Product 31", 370.03m, 5, 62, null },
                    { 32, new DateTime(2024, 12, 9, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality beauty product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+32", "Classic Beauty Product 32", 310.49m, 4, 271, null },
                    { 33, new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality food product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+33", "Essential Food Product 33", 262.46m, 3, 169, null },
                    { 34, new DateTime(2024, 3, 24, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality clothing product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+34", "Smart Clothing Product 34", 607.98m, 2, 94, null },
                    { 35, new DateTime(2024, 11, 17, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality food product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+35", "Essential Food Product 35", 83.66m, 5, 210, null },
                    { 36, new DateTime(2024, 12, 19, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality food product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+36", "Smart Food Product 36", 858.79m, 5, 233, null },
                    { 37, new DateTime(2024, 9, 15, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality clothing product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+37", "Deluxe Clothing Product 37", 200.12m, 3, 317, null },
                    { 38, new DateTime(2024, 3, 14, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality electronics product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+38", "Pro Electronics Product 38", 323.08m, 4, 260, null },
                    { 39, new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality sports product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+39", "Pro Sports Product 39", 533.57m, 5, 99, null },
                    { 40, new DateTime(2024, 4, 8, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality electronics product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+40", "Classic Electronics Product 40", 292.30m, 2, 85, null },
                    { 41, new DateTime(2024, 8, 29, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality beauty product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+41", "Vintage Beauty Product 41", 340.74m, 4, 226, null },
                    { 42, new DateTime(2024, 12, 8, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality beauty product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+42", "Modern Beauty Product 42", 780.90m, 1, 155, null },
                    { 43, new DateTime(2024, 6, 20, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality sports product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+43", "Deluxe Sports Product 43", 358.39m, 1, 478, null },
                    { 44, new DateTime(2024, 1, 7, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality beauty product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+44", "Modern Beauty Product 44", 837.41m, 5, 440, null },
                    { 45, new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality books product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+45", "Deluxe Books Product 45", 26.76m, 3, 445, null },
                    { 46, new DateTime(2024, 1, 12, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality toys product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+46", "Smart Toys Product 46", 276.58m, 4, 470, null },
                    { 47, new DateTime(2024, 5, 13, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality books product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+47", "Essential Books Product 47", 48.33m, 3, 342, null },
                    { 48, new DateTime(2024, 4, 27, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality books product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+48", "Classic Books Product 48", 554.62m, 4, 321, null },
                    { 49, new DateTime(2024, 12, 23, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality toys product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+49", "Premium Toys Product 49", 132.32m, 2, 421, null },
                    { 50, new DateTime(2024, 3, 7, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality books product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+50", "Premium Books Product 50", 531.41m, 1, 175, null },
                    { 51, new DateTime(2024, 3, 13, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality toys product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+51", "Premium Toys Product 51", 860.32m, 4, 90, null },
                    { 52, new DateTime(2024, 6, 2, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality toys product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+52", "Essential Toys Product 52", 784.56m, 4, 178, null },
                    { 53, new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality home product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+53", "Classic Home Product 53", 721.47m, 3, 277, null },
                    { 54, new DateTime(2024, 4, 23, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality home product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+54", "Essential Home Product 54", 887.27m, 2, 348, null },
                    { 55, new DateTime(2024, 10, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality sports product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+55", "Pro Sports Product 55", 634.41m, 3, 158, null },
                    { 56, new DateTime(2024, 5, 30, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality home product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+56", "Smart Home Product 56", 461.63m, 1, 429, null },
                    { 57, new DateTime(2024, 12, 13, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality home product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+57", "Classic Home Product 57", 516.45m, 1, 203, null },
                    { 58, new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality home product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+58", "Modern Home Product 58", 445.82m, 3, 357, null },
                    { 59, new DateTime(2024, 7, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality clothing product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+59", "Pro Clothing Product 59", 426.81m, 5, 453, null },
                    { 60, new DateTime(2024, 11, 3, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality clothing product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+60", "Smart Clothing Product 60", 804.65m, 4, 316, null },
                    { 61, new DateTime(2024, 8, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality sports product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+61", "Modern Sports Product 61", 66.89m, 5, 54, null },
                    { 62, new DateTime(2024, 5, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality beauty product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+62", "Deluxe Beauty Product 62", 148.59m, 1, 188, null },
                    { 63, new DateTime(2024, 11, 30, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality electronics product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+63", "Premium Electronics Product 63", 597.58m, 2, 10, null },
                    { 64, new DateTime(2024, 10, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality food product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+64", "Pro Food Product 64", 369.06m, 1, 299, null },
                    { 65, new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality books product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+65", "Deluxe Books Product 65", 55.16m, 4, 0, null },
                    { 66, new DateTime(2024, 9, 4, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality sports product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+66", "Pro Sports Product 66", 481.44m, 5, 359, null },
                    { 67, new DateTime(2024, 11, 4, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality beauty product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+67", "Modern Beauty Product 67", 373.83m, 4, 429, null },
                    { 68, new DateTime(2024, 12, 7, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality beauty product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+68", "Pro Beauty Product 68", 606.43m, 4, 44, null },
                    { 69, new DateTime(2024, 10, 24, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality food product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+69", "Classic Food Product 69", 650.63m, 5, 483, null },
                    { 70, new DateTime(2024, 5, 11, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality home product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+70", "Smart Home Product 70", 186.16m, 5, 135, null },
                    { 71, new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality sports product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+71", "Smart Sports Product 71", 836.28m, 5, 29, null },
                    { 72, new DateTime(2024, 11, 18, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality food product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+72", "Vintage Food Product 72", 103.44m, 1, 487, null },
                    { 73, new DateTime(2024, 4, 25, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality sports product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+73", "Smart Sports Product 73", 37.57m, 4, 277, null },
                    { 74, new DateTime(2024, 6, 18, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality clothing product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+74", "Classic Clothing Product 74", 681.96m, 1, 57, null },
                    { 75, new DateTime(2024, 12, 28, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality home product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+75", "Deluxe Home Product 75", 892.37m, 2, 354, null },
                    { 76, new DateTime(2024, 11, 16, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality home product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+76", "Deluxe Home Product 76", 488.46m, 2, 21, null },
                    { 77, new DateTime(2024, 5, 28, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality beauty product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+77", "Smart Beauty Product 77", 877.98m, 2, 157, null },
                    { 78, new DateTime(2024, 11, 1, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality food product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+78", "Pro Food Product 78", 59.33m, 3, 414, null },
                    { 79, new DateTime(2024, 8, 14, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality food product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+79", "Smart Food Product 79", 235.07m, 1, 439, null },
                    { 80, new DateTime(2024, 4, 13, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality sports product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+80", "Vintage Sports Product 80", 698.75m, 4, 226, null },
                    { 81, new DateTime(2024, 7, 6, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality books product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+81", "Classic Books Product 81", 112.16m, 3, 54, null },
                    { 82, new DateTime(2024, 10, 9, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality books product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+82", "Vintage Books Product 82", 626.50m, 4, 76, null },
                    { 83, new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality books product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+83", "Pro Books Product 83", 874.04m, 2, 169, null },
                    { 84, new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality home product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+84", "Deluxe Home Product 84", 109.12m, 5, 71, null },
                    { 85, new DateTime(2024, 10, 27, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality toys product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+85", "Deluxe Toys Product 85", 439.94m, 3, 455, null },
                    { 86, new DateTime(2024, 2, 6, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality electronics product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+86", "Vintage Electronics Product 86", 193.70m, 5, 340, null },
                    { 87, new DateTime(2024, 12, 25, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality books product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+87", "Essential Books Product 87", 350.24m, 3, 270, null },
                    { 88, new DateTime(2024, 4, 29, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality clothing product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+88", "Essential Clothing Product 88", 246.35m, 3, 237, null },
                    { 89, new DateTime(2024, 2, 15, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality toys product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+89", "Modern Toys Product 89", 167.33m, 1, 242, null },
                    { 90, new DateTime(2024, 11, 21, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality clothing product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+90", "Classic Clothing Product 90", 202.52m, 2, 363, null },
                    { 91, new DateTime(2024, 2, 26, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality electronics product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+91", "Vintage Electronics Product 91", 44.53m, 1, 430, null },
                    { 92, new DateTime(2024, 7, 24, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality sports product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+92", "Essential Sports Product 92", 789.74m, 1, 430, null },
                    { 93, new DateTime(2024, 4, 18, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality beauty product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+93", "Pro Beauty Product 93", 78.94m, 5, 62, null },
                    { 94, new DateTime(2024, 2, 26, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality electronics product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+94", "Modern Electronics Product 94", 80.67m, 2, 75, null },
                    { 95, new DateTime(2024, 9, 21, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality toys product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+95", "Essential Toys Product 95", 395.87m, 3, 40, null },
                    { 96, new DateTime(2024, 1, 14, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality beauty product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+96", "Deluxe Beauty Product 96", 330.71m, 3, 243, null },
                    { 97, new DateTime(2024, 11, 7, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality beauty product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+97", "Modern Beauty Product 97", 538.30m, 5, 54, null },
                    { 98, new DateTime(2024, 3, 5, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality home product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+98", "Pro Home Product 98", 218.34m, 3, 305, null },
                    { 99, new DateTime(2024, 2, 4, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality electronics product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+99", "Premium Electronics Product 99", 221.52m, 4, 458, null },
                    { 100, new DateTime(2024, 5, 31, 0, 0, 0, 0, DateTimeKind.Utc), "High-quality food product with excellent features. Perfect for everyday use and special occasions.", "https://via.placeholder.com/300x300?text=Product+100", "Smart Food Product 100", 183.20m, 2, 441, null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 100);
        }
    }
}
