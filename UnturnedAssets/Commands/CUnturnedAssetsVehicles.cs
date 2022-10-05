extern alias JetBrainsAnnotations;
using Cysharp.Threading.Tasks;
using JetBrainsAnnotations::JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using OpenMod.Core.Commands;
using OpenMod.Extensions.Games.Abstractions.Vehicles;
using OpenMod.Unturned.Commands;
using OpenMod.Unturned.Vehicles;
using System;
using System.Linq;
using UnturnedAssets.Database;
using UnturnedAssets.Database.Models;

namespace UnturnedAssets.Commands
{
    [UsedImplicitly]
    [Command("vehicles")]
    [CommandAlias("vehicle")]
    [CommandDescription("Update vehicle asset information.")]
    [CommandParent(typeof(CUnturnedAssets))]
    public class CUnturnedAssetsVehicles : UnturnedCommand
    {
        private readonly UnturnedAssetsDbContext _dbContext;
        private readonly IVehicleDirectory _vehicleDirectory;
        private readonly IStringLocalizer _stringLocalizer;

        public CUnturnedAssetsVehicles(
            UnturnedAssetsDbContext dbContext,
            IVehicleDirectory vehicleDirectory,
            IStringLocalizer stringLocalizer,
            IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _dbContext = dbContext;
            _vehicleDirectory = vehicleDirectory;
            _stringLocalizer = stringLocalizer;
        }

        protected override async UniTask OnExecuteAsync()
        {
            var assets = (await _vehicleDirectory.GetVehicleAssetsAsync()).OfType<UnturnedVehicleAsset>();

            var tableName = _dbContext.Model.FindEntityType(typeof(VehicleAsset)).GetTableName();

            await _dbContext.Database.ExecuteSqlRawAsync($"TRUNCATE TABLE `{tableName}`;");

            await _dbContext.VehicleAssets.AddRangeAsync(assets.Select(x => new VehicleAsset
            {
                VehicleId = ushort.Parse(x.VehicleAssetId),
                VehicleName = x.VehicleName,
                GUID = x.VehicleAsset.GUID
            }));

            var count = await _dbContext.SaveChangesAsync();

            await PrintAsync(_stringLocalizer["Commands:UnturnedAssets:Items", new { Count = count }]);
        }
    }
}
