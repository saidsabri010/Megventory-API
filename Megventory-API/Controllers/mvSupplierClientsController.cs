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
using System.Text;
using Newtonsoft.Json.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace Megventory_API.Controllers
{
    public class mvSupplierClientsController : Controller
    {
        private readonly IHttpClientFactory _context;
        public RootObject supplierClients { get; set; }
        public Filtering filtering { get; set; }

        const string BASE_URL = "https://api.megaventory.com/v2017a/";

        [ActivatorUtilitiesConstructor]
        public mvSupplierClientsController(IHttpClientFactory context)
        {
            _context = context;
        }
        // GET: mvSupplierClients
        public async Task<IActionResult> Index()
        {
            var message = new HttpRequestMessage();
            message.Method = HttpMethod.Get;
            message.RequestUri = new Uri($"{BASE_URL}json/reply/SupplierClientGet?APIKEY=609e6dc2acd38dc6@m128114");
            message.Headers.Add("Accept", "application/json");

            var client = _context.CreateClient();

            var response = await client.SendAsync(message);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                supplierClients = JsonConvert.DeserializeObject<RootObject>(responseBody);
            }
            else
            {
                //
            }

            return View(supplierClients.mvSupplierClients);
        }

        // GET: mvSupplierClients/Details/5
        public async Task<IActionResult> Details(string id)
        {


            return View();
        }

        // GET: mvSupplierClients/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: mvSupplierClients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(RootObjectPost rootObjectPost)
        {
            rootObjectPost.APIKEY = "609e6dc2acd38dc6@m128114";
            if (ModelState.IsValid)
            {
                HttpContent httpContent = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(rootObjectPost), Encoding.UTF8);
                System.Diagnostics.Debug.WriteLine("here we go !");
                System.Diagnostics.Debug.WriteLine(httpContent.ToString());
                httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var message = new HttpRequestMessage();
                message.Content = httpContent;
                message.Method = HttpMethod.Post;
                message.RequestUri = new Uri($"{BASE_URL}json/reply/SupplierClientUpdate");
                HttpClient client = _context.CreateClient();
                HttpResponseMessage response = await client.SendAsync(message);

                var result = await response.Content.ReadAsStringAsync();
                JObject jsonresult = JObject.Parse(result);
                System.Diagnostics.Debug.WriteLine("here is json :");
                System.Diagnostics.Debug.WriteLine(jsonresult);
                return RedirectToAction(nameof(Index));
            }

            return View(rootObjectPost);
        }
        [HttpGet]
        // GET: mvSupplierClients/Edit/5
        public async Task<IActionResult> Edit(int SupplierClientID)
        {
            //if (SupplierClientID.Equals(null))
            //{
            //    return NotFound();
            //}
            //var message = new HttpRequestMessage();
            //message.Method = HttpMethod.Get;
            //message.RequestUri = new Uri($"{BASE_URL}json/reply/SupplierClientGet");
            //message.Headers.Add("Accept", "application/json");

            //var client = _context.CreateClient();

            //var response = await client.SendAsync(message);

            //RootObject supplierStudent = null;

            //if (response.IsSuccessStatusCode)
            //{
            //    var responseBody = await response.Content.ReadAsStringAsync();
            //    supplierClients = JsonConvert.DeserializeObject<RootObject>(responseBody);
            //}
            //if (supplierStudent == null)
            //{
            //    return NotFound();
            //}
            return View();
        }

        // POST: mvSupplierClients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("SupplierClientID,SupplierClientName,SupplierClientEmail,SupplierClientBillingAddress,SupplierClientPhone1")] mvSupplierClients mvSupplierClients)
        {
            return View();
        }

        // GET: mvSupplierClients/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            return View();
        }

        // POST: mvSupplierClients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            return RedirectToAction(nameof(Index));
        }

        //private bool mvSupplierClientsExists(string id)
        //{
        //    return _context.mvSupplierClients.Any(e => e.SupplierClientName == id);
        //}
    }
}
