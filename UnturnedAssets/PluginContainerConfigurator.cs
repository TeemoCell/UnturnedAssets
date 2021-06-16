extern alias JetBrainsAnnotations;
using JetBrainsAnnotations::JetBrains.Annotations;
using Microsoft.Extensions.DependencyInjection;
using OpenMod.API.Plugins;
using OpenMod.EntityFrameworkCore.Extensions;
using UnturnedAssets.Database;

namespace UnturnedAssets
{
    [UsedImplicitly]
    public class PluginContainerConfigurator : IPluginContainerConfigurator
    {
        public void ConfigureContainer(IPluginServiceConfigurationContext context)
        {
            context.ContainerBuilder.AddEntityFrameworkCoreMySql();
            context.ContainerBuilder.AddDbContext<UnturnedAssetsDbContext>(ServiceLifetime.Transient);
        }
    }
}
