using System;
using System.ComponentModel.DataAnnotations;

namespace UnturnedAssets.Database.Models
{
    [Serializable]
    public class VehicleAsset
    {
        [Key]
        public ushort VehicleId { get; set; }

        public string VehicleName { get; set; } = "";

        public Guid GUID { get; set; }
    }
}
