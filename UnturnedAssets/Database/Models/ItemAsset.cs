using SDG.Unturned;
using System;
using System.ComponentModel.DataAnnotations;

namespace UnturnedAssets.Database.Models
{
    [Serializable]
    public class ItemAsset
    {
        [Key]
        public ushort Id { get; set; }

        public string Name { get; set; } = "";

        public Guid GUID { get; set; }

        public string Description { get; set; } = "";

        public EItemRarity Rarity { get; set; }

        public EItemType Type { get; set; }

        public EAssetType AssetType { get; set; }

        public string Path { get; set; } = "";
    }
}
