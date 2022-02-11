using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Megventory_API.Models
{
    public class MvProducts
    {
        [JsonProperty(PropertyName = "APIKEY")]
        public string APIKEY { get; set; }
        [JsonProperty(PropertyName = "mvProduct")]
        public mvProducts mvProduct { get; set; }
    }
    public class Product
    {
        [JsonProperty(PropertyName = "mvProducts")]
        public List<mvProducts> mvProducts { get; set; }
    }

    public class mvProducts
    {
        [Key]
        [JsonProperty(PropertyName = "ProductID")]
        public int ProductID { get; set; }

        [JsonProperty(PropertyName = "ProductSKU")]
        public string ProductSKU { get; set; }

        [JsonProperty(PropertyName = "ProductDescription")]
        public string ProductDescription { get; set; }

        [JsonProperty(PropertyName = "ProductSellingPrice")]
        public double ProductSellingPrice { get; set; }

        [JsonProperty(PropertyName = "ProductPurchasePrice")]
        public double ProductPurchasePrice { get; set; }
    }
}
