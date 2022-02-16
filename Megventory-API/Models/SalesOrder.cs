using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Megventory_API.Models
{
    public class makingOrders
    {
        [JsonProperty(PropertyName = "APIKEY")]
        public string APIKEY { get; set; }
        [JsonProperty(PropertyName = "mvSalesOrder")]
        public mvSalesOrder mvSalesOrders { get; set; }
    }
    public class mvSalesOrder
    {
        [Key]
        [JsonProperty(PropertyName = "SalesOrderTypeId")]
        public string SalesOrderTypeId { get; set; }
        [JsonProperty(PropertyName = "SalesOrderClientName")]
        public string SalesOrderClientName { get; set; }
        [JsonProperty(PropertyName = "SalesOrderInventoryLocationID")]
        public int SalesOrderInventoryLocationID { get; set; }
        [JsonProperty(PropertyName = "SalesOrderStatus")]
        public int SalesOrderStatus { get; set; }
        [JsonProperty(PropertyName = "SalesOrderDetails")]
        public SalesOrdersDetails[] SalesOrderDetails { get; set; }

    }
    public class SalesOrdersDetails
    {
        [JsonProperty(PropertyName = "SalesOrderRowProductSKU")]
        public string SalesOrderRowProductSKU { get; set; }
        [JsonProperty(PropertyName = "SalesOrderRowQuantity")]
        public int SalesOrderRowQuantity { get; set; }
        [JsonProperty(PropertyName = "SalesOrderRowUnitPriceWithTaxAndDiscount")]
        public int SalesOrderRowUnitPriceWithTaxAndDiscount { get; set; }
    }
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
