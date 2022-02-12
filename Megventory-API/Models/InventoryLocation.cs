using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Megventory_API.Models
{
    public class InventoryLocation
    {
        [JsonProperty(PropertyName = "mvInventoryLocations")]
        public mvInventoryLocations mvInventoryLocations { get; set; }
    }

    public class mvInventoryLocations
    {
        [JsonProperty(PropertyName = "InventoryLocationAbbreviation")]
        public bool InventoryLocationAbbreviation { get; set; }

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
