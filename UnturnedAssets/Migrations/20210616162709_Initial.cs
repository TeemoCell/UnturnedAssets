using Microsoft.EntityFrameworkCore.Migrations;
using SDG.Unturned;

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
                    Id = table.Column<ushort>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    GUID = table.Column<string>(maxLength: 128, nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Rarity = table.Column<string>(nullable: false),
                    Type = table.Column<string>(nullable: false),
                    AssetType = table.Column<string>(nullable: false),
                    Path = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnturnedAssets_ItemAssets", x => x.GUID);
                });

            migrationBuilder.CreateTable(
                name: "UnturnedAssets_VehicleAssets",
                columns: table => new
                {
                    VehicleId = table.Column<ushort>(nullable: false),
                    VehicleName = table.Column<string>(nullable: false),
                    GUID = table.Column<string>(maxLength: 128, nullable: false),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnturnedAssets_VehicleAssets", x => x.GUID);
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
