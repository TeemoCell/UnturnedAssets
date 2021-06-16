using Microsoft.EntityFrameworkCore.Migrations;

namespace UnturnedAssets.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnturnedAssets_ItemAssets",
                columns: table => new
                {
                    ItemId = table.Column<ushort>(nullable: false),
                    ItemName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnturnedAssets_ItemAssets", x => x.ItemId);
                });

            migrationBuilder.CreateTable(
                name: "UnturnedAssets_VehicleAssets",
                columns: table => new
                {
                    VehicleId = table.Column<ushort>(nullable: false),
                    VehicleName = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnturnedAssets_VehicleAssets", x => x.VehicleId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnturnedAssets_ItemAssets");

            migrationBuilder.DropTable(
                name: "UnturnedAssets_VehicleAssets");
        }
    }
}
