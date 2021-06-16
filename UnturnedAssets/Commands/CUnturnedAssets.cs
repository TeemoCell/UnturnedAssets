extern alias JetBrainsAnnotations;
using Cysharp.Threading.Tasks;
using OpenMod.Core.Commands;
using OpenMod.Unturned.Commands;
using System;

namespace UnturnedAssets.Commands
{
    [Command("unturnedassets")]
    [CommandAlias("unturnedasset")]
    [CommandSyntax("<items | vehicles>")]
    [CommandDescription("Update asset information.")]
    public class CUnturnedAssets : UnturnedCommand
    {
        public CUnturnedAssets(IServiceProvider serviceProvider) : base(serviceProvider)
        {
        }

        protected override UniTask OnExecuteAsync()
        {
            throw new CommandWrongUsageException(Context);
        }
    }
}
