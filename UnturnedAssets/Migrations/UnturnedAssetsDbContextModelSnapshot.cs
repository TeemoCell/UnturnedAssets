﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UnturnedAssets.Database;

namespace UnturnedAssets.Migrations
{
    [DbContext(typeof(UnturnedAssetsDbContext))]
    partial class UnturnedAssetsDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("UnturnedAssets.Database.Models.ItemAsset", b =>
                {
                    b.Property<ushort>("ItemId")
                        .HasColumnType("smallint unsigned");

                    b.Property<string>("ItemName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<int>("ItemRarity")
                        .HasColumnType("int");

                    b.HasKey("ItemId");

                    b.ToTable("UnturnedAssets_ItemAssets");
                });

            modelBuilder.Entity("UnturnedAssets.Database.Models.VehicleAsset", b =>
                {
                    b.Property<ushort>("VehicleId")
                        .HasColumnType("smallint unsigned");

                    b.Property<string>("VehicleName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("VehicleId");

                    b.ToTable("UnturnedAssets_VehicleAssets");
                });
#pragma warning restore 612, 618
        }
    }
}
