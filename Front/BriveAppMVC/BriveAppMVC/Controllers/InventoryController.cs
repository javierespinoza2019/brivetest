namespace BriveAppMVC.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text;
    using System.Threading.Tasks;
    using BriveAppMVC.Common.Helper;
    using BriveAppMVC.Models;
    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;

    public class InventoryController : Controller
    {       
        private HttpClientHandler clientHandler = new HttpClientHandler();
        public InventoryController()
        {           
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            };
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<object> GetAll(InventoryModel item)
        {
            string responseContent = string.Empty;
            StringContent content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
            using (var client = new HttpClient(clientHandler))
            {
                using var response = await client.PostAsync(HelperManager.INVENTORY_ENDPOINT_SERVICE, content);
                responseContent = await response.Content.ReadAsStringAsync();
            }
            return responseContent;
        }

        [HttpGet]
        public async Task<object> Products()
        {
            string responseJson = string.Empty;
            using (var client = new HttpClient(clientHandler))
            {
                using var response = await client.GetAsync(HelperManager.PRODUCT_ENDPOINT_SERVICE);
                responseJson = await response.Content.ReadAsStringAsync();
            }
            return responseJson;
        }

        [HttpGet]
        public async Task<object> Stores()
        {
            string responseJson = string.Empty;
            using (var client = new HttpClient(clientHandler))
            {
                using var response = await client.GetAsync(HelperManager.STORE_ENDPOINT_SERVICE);
                responseJson = await response.Content.ReadAsStringAsync();
            }
            return responseJson;
        }

        [HttpPost]
        public async Task<object> AddMovement(InventoryModel item)
        {
            string responseJson = string.Empty;
            item.TransactionDate = DateTime.Now;
            StringContent content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
            using (var client = new HttpClient(clientHandler))
            {
                using var response = await client.PostAsync(HelperManager.INVENTORY_ADD_ENDPOINT_SERVICE, content);
                responseJson = await response.Content.ReadAsStringAsync();
            }
            return responseJson;
        }

        [HttpPost]
        public async Task<object> AddProduct(ProductModel item)
        {
            string responseJson = string.Empty;
            StringContent content = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
            using (var client = new HttpClient(clientHandler))
            {
                using var response = await client.PostAsync(HelperManager.PRODUCT_ADD_ENDPOINT_SERVICE, content);
                responseJson = await response.Content.ReadAsStringAsync();
            }
            return responseJson;
        }
    }
}
