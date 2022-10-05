extern alias JetBrainsAnnotations;
using Cysharp.Threading.Tasks;
using JetBrainsAnnotations::JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using OpenMod.Core.Commands;
using OpenMod.Extensions.Games.Abstractions.Items;
using OpenMod.Unturned.Commands;
using OpenMod.Unturned.Items;
using System;
using System.Linq;
using UnturnedAssets.Database;
using UnturnedAssets.Database.Models;

namespace UnturnedAssets.Commands
{
    [UsedImplicitly]
    [Command("items")]
    [CommandAlias("item")]
    [CommandDescription("Update item asset information.")]
    [CommandParent(typeof(CUnturnedAssets))]
    public class CUnturnedAssetsItems : UnturnedCommand
    {
        private readonly UnturnedAssetsDbContext _dbContext;
        private readonly IItemDirectory _itemDirectory;
        private readonly IStringLocalizer _stringLocalizer;

        public CUnturnedAssetsItems(
            UnturnedAssetsDbContext dbContext,
            IItemDirectory itemDirectory,
            IStringLocalizer stringLocalizer,
            IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _dbContext = dbContext;
            _itemDirectory = itemDirectory;
            _stringLocalizer = stringLocalizer;
        }

        protected override async UniTask OnExecuteAsync()
        {
            var assets = (await _itemDirectory.GetItemAssetsAsync()).OfType<UnturnedItemAsset>();

            var tableName = _dbContext.Model.FindEntityType(typeof(ItemAsset)).GetTableName();

            await _dbContext.Database.ExecuteSqlRawAsync($"TRUNCATE TABLE `{tableName}`;");

            await _dbContext.ItemAssets.AddRangeAsync(assets
                .Select(x => new ItemAsset
                {
                    Id = ushort.Parse(x.ItemAssetId),
                    GUID = x.ItemAsset.GUID,
                    Name = x.ItemName,
                    Rarity = x.ItemAsset.rarity,
                    Description = x.ItemAsset.itemDescription,
                    ItemType = x.ItemAsset.type,
                    AssetType = x.ItemAsset.assetCategory,
                    Path = x.ItemAsset.getFilePath()
                }));

            var count = await _dbContext.SaveChangesAsync();

            await PrintAsync(_stringLocalizer["Commands:UnturnedAssets:Items", new {Count = count}]);
        }
    }
}
