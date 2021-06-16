using System;
using System.ComponentModel.DataAnnotations;
using SDG.Unturned;

namespace UnturnedAssets.Database.Models
{
    [Serializable]
    public class ItemAsset
    {
        [Key]
        public ushort ItemId { get; set; }

        public string ItemName { get; set; } = "";

        public EItemRarity ItemRarity { get; set; }
    }
}
