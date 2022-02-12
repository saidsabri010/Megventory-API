using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace Megventory_API.Models
{
    public class mvInventoryLocationsObject
    {
        [JsonProperty(PropertyName = "APIKEY")]
        public string APIKEY { get; set; }
        [JsonProperty(PropertyName = "mvInventoryLocation")]
        public mvInventoryLocations mvInventoryLocation { get; set; }
    }
    public class InventoryLocation
    {
        [JsonProperty(PropertyName = "mvInventoryLocations")]
        public List<mvInventoryLocations> mvInventoryLocations { get; set; }
    }
    public class mvInventoryLocations
    {
        [Key]
        [JsonProperty(PropertyName = "InventoryLocationID")]
        public bool InventoryLocationID { get; set; }

        [JsonProperty(PropertyName = "InventoryLocationAbbreviation")]
        public string InventoryLocationAbbreviation { get; set; }

        [JsonProperty(PropertyName = "InventoryLocationName")]
        public string InventoryLocationName { get; set; }

        [JsonProperty(PropertyName = "Address")]
        public Address Address { get; set; }
    }
    public class Address
    {
        [JsonProperty(PropertyName = "AddressType")]
        public string AddressType { get; set; }

        [JsonProperty(PropertyName = "AddressLine1")]
        public string AddressLine1 { get; set; }

        [JsonProperty(PropertyName = "CountryName")]
        public string CountryName { get; set; }

        [JsonProperty(PropertyName = "ZipCode")]
        public string ZipCode { get; set; }
    }
}
