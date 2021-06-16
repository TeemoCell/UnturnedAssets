using Microsoft.EntityFrameworkCore.Migrations;

namespace UnturnedAssets.Migrations
{
    public partial class AddedItemRarity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ItemRarity",
                table: "UnturnedAssets_ItemAssets",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemRarity",
                table: "UnturnedAssets_ItemAssets");
        }
    }
}
