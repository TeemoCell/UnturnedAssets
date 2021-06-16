using System;
using System.ComponentModel.DataAnnotations;

namespace UnturnedAssets.Database.Models
{
    [Serializable]
    public class ItemAsset
    {
        [Key]
        public ushort ItemId { get; set; }

        public string ItemName { get; set; } = "";
    }
}
