using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Megventory_API.Models
{
    public class SalesOrder
    {
        [JsonProperty(PropertyName = "mvSalesOrders")]
        public List<mvSalesOrders> mvSalesOrders { get; set; }
    }

    public class mvSalesOrders
    {
        [Key]
        [JsonProperty(PropertyName = "SalesOrderId")]
        public int SalesOrderId { get; set; }
        [JsonProperty(PropertyName = "SalesOrderClientName")]
        public string SalesOrderClientName { get; set; }
        [JsonProperty(PropertyName = "SalesOrderDetails")]
        public SalesOrderDetails[] SalesOrderDetails { get; set; }
        [JsonProperty(PropertyName = "SalesOrderStatus")]
        public string SalesOrderStatus { get; set; }
    }

    public class SalesOrderDetails
    {
        [JsonProperty(PropertyName = "SalesOrderRowDetailID")]
        public int SalesOrderRowDetailID { get; set; }

        [JsonProperty(PropertyName = "SalesOrderRowProductSKU")]
        public string SalesOrderRowProductSKU { get; set; }
        [JsonProperty(PropertyName = "SalesOrderRowProductDescription")]
        public string SalesOrderRowProductDescription { get; set; }
    }
}
