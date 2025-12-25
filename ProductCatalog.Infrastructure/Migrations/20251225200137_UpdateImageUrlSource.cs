using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProductCatalog.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateImageUrlSource : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Update all products to use a new image URL pattern
            // Example: Update to use a different placeholder service or real images

            migrationBuilder.Sql(
                @"
                    UPDATE ""Products""
                    SET ""ImageUrl"" = 'https://picsum.photos/300/300?random=' || ""Id""::text
                "
                );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Revert to original placeholder URLs

            migrationBuilder.Sql(
               @"
                    UPDATE ""Products""
                    SET ""ImageUrl"" = 'https://via.placeholder.com/300x300?text=Product+' || ""Id""::text
                "
               );
        }
    }
}
