using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        
        Helper.Helper.API _api = new Helper.Helper.API();
        private readonly ILogger<HomeController> _logger;

        

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        

        public async Task<IActionResult> Index()
        {
            
            List<ProductModel> productdata = new List<ProductModel>();
            HttpClient client = _api.initial();
            HttpResponseMessage res = await client.GetAsync("api/Product");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                productdata = JsonConvert.DeserializeObject<List<ProductModel>>(results);
            }
            
            return View(productdata);
            
        }
        [HttpPost]
        public IActionResult Create(ProductModel product)
        {
            HttpClient client = _api.initial();

            //Http Post
            var postTask = client.PostAsJsonAsync<ProductModel>("api/Product", product);
            postTask.Wait();
            var result = postTask.Result;
            if (result.IsSuccessStatusCode)
            {
                return RedirectToAction("Dasahboard");
            }
            return View();
        }
        public IActionResult Edit(ProductModel product)
        {
            using (HttpClient httpClient = _api.initial())
            {
                httpClient.BaseAddress = new Uri("https://localhost:7255/api/Product");

                //HTTP POST
                var putTask = httpClient.PutAsJsonAsync<ProductModel>("Product", product);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Dashboard");
                }
            }
            return View(product);
        }
        public async Task<IActionResult> Delete(int Id)
        {
            var stajyer = new ProductModel();
            HttpClient client = _api.initial();
            HttpResponseMessage res = await client.DeleteAsync($"api/Product/{Id}");
            return RedirectToAction("Dashboard");
        }


        public async Task<IActionResult> Dashboard()
        {
            List<ProductModel> productdata = new List<ProductModel>();
            HttpClient client = _api.initial();
            HttpResponseMessage res = await client.GetAsync("api/Product");
            if (res.IsSuccessStatusCode)
            {
                var results = res.Content.ReadAsStringAsync().Result;
                productdata = JsonConvert.DeserializeObject<List<ProductModel>>(results);
            }

            return View(productdata);
           
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}