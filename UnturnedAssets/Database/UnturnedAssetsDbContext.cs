using Microsoft.EntityFrameworkCore;
using SilK.OpenMod.EntityFrameworkCore;
using System;
using UnturnedAssets.Database.Models;

namespace UnturnedAssets.Database
{
    public class UnturnedAssetsDbContext : OpenModPomeloDbContext<UnturnedAssetsDbContext>
    {
        public UnturnedAssetsDbContext(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        public UnturnedAssetsDbContext(DbContextOptions<UnturnedAssetsDbContext> options,
            IServiceProvider serviceProvider) : base(options, serviceProvider)
        {
        }

        public DbSet<ItemAsset> ItemAssets => Set<ItemAsset>();

        public DbSet<VehicleAsset> VehicleAssets => Set<VehicleAsset>();
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ItemAsset>()
                .HasKey(x => x.Id);

            modelBuilder.Entity<ItemAsset>()
                .Property(x => x.Id)
                .ValueGeneratedNever();

            modelBuilder.Entity<VehicleAsset>()
                .HasKey(x => x.VehicleId);

            modelBuilder.Entity<VehicleAsset>()
                .Property(x => x.VehicleId)
                .ValueGeneratedNever();
        }
    }
}
