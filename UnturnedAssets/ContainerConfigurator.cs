extern alias JetBrainsAnnotations;
using JetBrainsAnnotations::JetBrains.Annotations;
using OpenMod.API.Plugins;
using SilK.OpenMod.EntityFrameworkCore;

namespace UnturnedAssets
{
    [UsedImplicitly]
    public class ContainerConfigurator : IPluginContainerConfigurator
    {
        public void ConfigureContainer(IPluginServiceConfigurationContext context)
        {
            context.ContainerBuilder.AddPomeloMySqlConnectorResolver();
        }
    }
}
