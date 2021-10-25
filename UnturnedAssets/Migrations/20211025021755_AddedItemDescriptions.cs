using Microsoft.EntityFrameworkCore.Migrations;

namespace UnturnedAssets.Migrations
{
    public partial class AddedItemDescriptions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ItemDescription",
                table: "UnturnedAssets_ItemAssets",
                nullable: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemDescription",
                table: "UnturnedAssets_ItemAssets");
        }
    }
}
