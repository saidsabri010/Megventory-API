using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Megventory_API.Models
{
    public class Filtering
    {
        [JsonProperty(PropertyName = "APIKEY")]
        public string APIKEY { get; set; }
        [JsonProperty(PropertyName = "Filters")]
        public List<Filters> Filters { get; set; }
    }
    public class Filters
    {
        [JsonProperty(PropertyName = "FieldName")]
        public string FieldName { get; set; }
        [JsonProperty(PropertyName = "SearchOperator")]
        public string SearchOperator { get; set; }
        [JsonProperty(PropertyName = "SearchValue")]
        public int SearchValue { get; set; }
    }
    public class RootObjectPost 
    {
        [JsonProperty(PropertyName = "APIKEY")]
        public string APIKEY { get; set; }
        [JsonProperty(PropertyName = "mvSupplierClient")]
        public mvSupplierClients mvSupplierClient { get; set; }
    }
    public class RootObject
    {
        [JsonProperty(PropertyName = "mvSupplierClients")]
        public List<mvSupplierClients> mvSupplierClients { get; set; }
    }
    public class mvSupplierClients
    {
        [Key]
        [JsonProperty(PropertyName = "SupplierClientID")]
        public int SupplierClientID { get; set; }
        [JsonProperty(PropertyName = "SupplierClientName")]
        public string SupplierClientName { get; set; }
        [JsonProperty(PropertyName = "SupplierClientType")]
        public string SupplierClientType { get; set; }
        [JsonProperty(PropertyName = "SupplierClientBillingAddress")]
        public string SupplierClientBillingAddress { get; set; }
        [JsonProperty(PropertyName = "SupplierClientPhone1")]
        public string SupplierClientPhone1 { get; set; }
    }
    
}
