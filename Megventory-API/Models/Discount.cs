using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Megventory_API.Models
{
    public class AddDsicount
    {
        [JsonProperty(PropertyName = "APIKEY")]
        public string APIKEY { get; set; }
        [JsonProperty(PropertyName = "mvDiscount")]
        public mvDiscounts mvDiscount { get; set; }
    }
    public class Discount
    {
        [JsonProperty(PropertyName = "mvDiscounts")]
        public List<mvDiscounts> mvDiscounts { get; set; }
    }
    public class mvDiscounts
    {
        [Key]
        [JsonProperty(PropertyName = "DiscountID")]
        public int DiscountID { get; set; }

        [JsonProperty(PropertyName = "DiscountName")]
        public string DiscountName { get; set; }

        [JsonProperty(PropertyName = "DiscountDescription")]
        public string DiscountDescription { get; set; }

        [JsonProperty(PropertyName = "DiscountValue")]
        public double DiscountValue { get; set; }
    }
}
