using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Megventory_API.Data;
using Megventory_API.Models;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace Megventory_API.Controllers
{
    public class mvProductsController : Controller
    {
        private readonly IHttpClientFactory _context;

        public Product products { get; set; }

        const string BASE_URL = "https://api.megaventory.com/v2017a/";

        public mvProductsController(IHttpClientFactory context)
        {
            _context = context;
        }

        // GET: mvProducts
        public async Task<IActionResult> Index()
        {
            var message = new HttpRequestMessage();
            message.Method = HttpMethod.Get;
            message.RequestUri = new Uri($"{BASE_URL}json/reply/ProductGet?APIKEY=609e6dc2acd38dc6@m128114");
            message.Headers.Add("Accept", "application/json");

            var client = _context.CreateClient();

            var response = await client.SendAsync(message);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                products = JsonConvert.DeserializeObject<Product>(responseBody);
            }
            else
            {
                //
            }
            return View(products.mvProducts);
        }

        // GET: mvProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {

            return View();
        }

        // GET: mvProducts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: mvProducts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(MvProducts product)
        {
            product.APIKEY = "609e6dc2acd38dc6@m128114";
            if (ModelState.IsValid)
            {
                HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(product), Encoding.UTF8);
                System.Diagnostics.Debug.WriteLine("here we go !");
                System.Diagnostics.Debug.WriteLine(httpContent.ToString());
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var message = new HttpRequestMessage();
                message.Content = httpContent;
                message.Method = HttpMethod.Post;
                message.RequestUri = new Uri($"{BASE_URL}json/reply/ProductUpdate");
                HttpClient client = _context.CreateClient();
                HttpResponseMessage response = await client.SendAsync(message);

                var result = await response.Content.ReadAsStringAsync();
                JObject jsonresult = JObject.Parse(result);
                System.Diagnostics.Debug.WriteLine("here is json :");
                System.Diagnostics.Debug.WriteLine(jsonresult);
                return RedirectToAction(nameof(Index));
            }
            return View(product);
        }

        // GET: mvProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            return View();
        }

        // POST: mvProducts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProductID,ProductSKU,ProductDescription,ProductSellingPrice,ProductPurchasePrice")] mvProducts mvProducts)
        {
            return View();
        }

        // GET: mvProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            return View();
        }

        // POST: mvProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            return RedirectToAction(nameof(Index));
        }

        //private bool mvProductsExists(int id)
        //{
        //    return _context.mvProducts.Any(e => e.ProductID == id);
        //}
    }
}
