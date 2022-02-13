using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Megventory_API.Models
{
    public class AddTax
    {
        [JsonProperty(PropertyName = "APIKEY")]
        public string APIKEY { get; set; }
        [JsonProperty(PropertyName = "mvTax")]
        public Taxes mvTax { get; set; }
    }
    public class Tax
    {
        [JsonProperty(PropertyName = "mvTaxes")]
        public List<Taxes> mvTaxes { get; set; }
    }
    public class Taxes
    {
        [Key]
        [JsonProperty(PropertyName = "TaxID")]
        public int mvTaxes { get; set; }

        [JsonProperty(PropertyName = "TaxName")]
        public string TaxName { get; set; }

        [JsonProperty(PropertyName = "TaxDescription")]
        public string TaxDescription { get; set; }

        [JsonProperty(PropertyName = "TaxValue")]
        public double TaxValue { get; set; }
    }
}
