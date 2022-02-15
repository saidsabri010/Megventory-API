using Megventory_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace Megventory_API.Controllers
{
    public class SalesOrdersController : Controller
    {
        private readonly IHttpClientFactory _context;
        public SalesOrder salesOrder { get; set; }

        const string BASE_URL = "https://api.megaventory.com/v2017a/";

        [ActivatorUtilitiesConstructor]
        public SalesOrdersController(IHttpClientFactory context)
        {
            _context = context;
        }
        public async Task<IActionResult> IndexAsync()
        {
            var message = new HttpRequestMessage();
            message.Method = HttpMethod.Get;
            message.RequestUri = new Uri($"{BASE_URL}json/reply/SalesOrderGet?APIKEY=609e6dc2acd38dc6@m128114");
            message.Headers.Add("Accept", "application/json");

            var client = _context.CreateClient();

            var response = await client.SendAsync(message);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                salesOrder = JsonConvert.DeserializeObject<SalesOrder>(responseBody);
            }
            else
            {
                //
            }

            return View(salesOrder.mvSalesOrders);
        }
    }
}
