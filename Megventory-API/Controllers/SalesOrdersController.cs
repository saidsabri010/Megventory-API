using Megventory_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
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
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(makingOrders orders)
        {
            orders.APIKEY = "609e6dc2acd38dc6@m128114";
            if (ModelState.IsValid)
            {
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(orders), Encoding.UTF8);
                System.Diagnostics.Debug.WriteLine("here we go !");
                System.Diagnostics.Debug.WriteLine(httpContent.ToString());
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var message = new HttpRequestMessage();
                message.Content = httpContent;
                message.Method = HttpMethod.Post;
                message.RequestUri = new Uri($"{BASE_URL}json/reply/SalesOrderUpdate");
                HttpClient client = _context.CreateClient();
                HttpResponseMessage response = await client.SendAsync(message);

                var result = await response.Content.ReadAsStringAsync();
                JObject jsonresult = JObject.Parse(result);
                System.Diagnostics.Debug.WriteLine("here is json :");
                System.Diagnostics.Debug.WriteLine(jsonresult);
                return RedirectToAction(nameof(Index));
            }
            return View(orders);
        }
    }
}
