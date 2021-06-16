using Cysharp.Threading.Tasks;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using OpenMod.API.Plugins;
using OpenMod.Unturned.Plugins;
using System;
using UnturnedAssets.Database;

[assembly: PluginMetadata("UnturnedAssets", DisplayName = "Unturned Assets",
    Author = "SilK", Website = "https://github.com/SilKsPlugins/UnturnedAssets")]

namespace UnturnedAssets
{
    [UsedImplicitly]
    public class UnturnedAssetsPlugin : OpenModUnturnedPlugin
    {
        private readonly UnturnedAssetsDbContext _dbContext;

        public UnturnedAssetsPlugin(
            UnturnedAssetsDbContext dbContext,
            IServiceProvider serviceProvider) : base(serviceProvider)
        {
            _dbContext = dbContext;
        }

        protected override async UniTask OnLoadAsync()
        {
            try
            {
                await _dbContext.Database.MigrateAsync();
            }
            catch (ArgumentNullException ex)
            {
                if (ex.ParamName == "connectionString")
                {
                    throw new Exception("No connection string is specified in the configuration.");
                }
            }
            catch (InvalidOperationException ex) when (ex.InnerException?.Message == "Unable to connect to any of the specified MySQL hosts.")
            {
                throw new Exception("The configured connection string is incorrect.");
            }
        }
    }
}
