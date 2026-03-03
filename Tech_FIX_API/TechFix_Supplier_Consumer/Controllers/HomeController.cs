using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Tech_FIX_API.Models;

namespace TechFix_Supplier_Consumer.Controllers
{
    public class HomeController : Controller
    {
        public async Task<ActionResult> GetProducts()
        {
            List<Tech_FIX_API.Models.Product> reservationList = new List<Tech_FIX_API.Models.Product>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:9279/api/Products"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservationList = JsonConvert.DeserializeObject<List<Product>>(apiResponse);
                }
            }
            return View(reservationList);
        }
        // ADD PRODUCT CODE  

        public async Task<ActionResult> AddProduct()
        {
            return View();
        }


        [HttpPost]

        public async Task<ActionResult> AddProduct(Product pr)
        {
            Product p = new Product();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(pr), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("http://localhost:9279/api/Products", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    JsonConvert.DeserializeObject<Product>(apiResponse);
                }
            }
            return RedirectToAction("GetProducts");
        }

        // UPDATE PRODUCT
        public async Task<ActionResult> UpdateProduct(string id)
        {
            Product product = new Product();

            using (var httpClient = new HttpClient())
            {
                try
                {
                    using (var response = await httpClient.GetAsync($"http://localhost:9279/api/Products/{id}"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            product = JsonConvert.DeserializeObject<Product>(apiResponse);
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Error fetching product details.");
                        }
                    }
                }
                catch (HttpRequestException ex)
                {
                    ModelState.AddModelError(string.Empty, $"Request error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                }
            }

            return View(product);
        }
        //----------------------------------------------------------------------------------------------------

        [HttpPost]
        public async Task<ActionResult> UpdateProduct(Product pr)
        {
            if (!ModelState.IsValid)
            {
                return View(pr);
            }

            using (var httpClient = new HttpClient())
            {
                try
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(pr), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync($"http://localhost:9279/api/Products/{pr.ProductID}", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            // Optionally, redirect or provide a success message
                            return RedirectToAction("GetProducts");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Error updating the product.");
                        }
                    }
                }
                catch (HttpRequestException ex)
                {
                    ModelState.AddModelError(string.Empty, $"Request error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                }
            }

            return View(pr);
        }


        [HttpGet]
        public async Task<ActionResult> DeleteProduct(int id)
        {
            Product p = new Product();
            using (var httpClient = new HttpClient())
            using (var response = await httpClient.DeleteAsync($"http://localhost:9279/api/Products/{id}"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                p = JsonConvert.DeserializeObject<Product>(apiResponse);
                return RedirectToAction("GetProducts");
            }
        }

        //Quotations
        public async Task<ActionResult> GetQuotations()
        {
            List<Tech_FIX_API.Models.Quotation> reservationList = new List<Tech_FIX_API.Models.Quotation>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:9279/api/Quotations"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservationList = JsonConvert.DeserializeObject<List<Quotation>>(apiResponse);
                }
            }
            return View(reservationList);
        }


        //Add New Quotations
        public async Task<ActionResult> AddQUotation()
        {
            return View();
        }

        [HttpPost]

        public async Task<ActionResult> AddQuotation(Quotation pr)
        {
            Quotation p = new Quotation();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(pr), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("http://localhost:9279/api/Quotations", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    JsonConvert.DeserializeObject<Quotation>(apiResponse);
                }
            }
            return RedirectToAction("GetQuotations");
        }

        // UPDATE Quotations
        public async Task<ActionResult> UpdateQuotation(string id)
        {
         Quotation qr = new Quotation();

            using (var httpClient = new HttpClient())
            {
                try
                {
                    using (var response = await httpClient.GetAsync($"http://localhost:9279/api/Quotations/{id}"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            qr = JsonConvert.DeserializeObject<Quotation>(apiResponse);
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Error fetching product details.");
                        }
                    }
                }
                catch (HttpRequestException ex)
                {
                    ModelState.AddModelError(string.Empty, $"Request error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                }
            }

            return View(qr);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateQuotation(Quotation qr) {
            if (!ModelState.IsValid)
            {
                return View(qr);
            }

            using (var httpClient = new HttpClient())
            {
                try
                {
                    StringContent content = new StringContent(JsonConvert.SerializeObject(qr), Encoding.UTF8, "application/json");
                    using (var response = await httpClient.PutAsync($"http://localhost:9279/api/Quotations/{qr.QuoteID}", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            // Optionally, redirect or provide a success message
                            return RedirectToAction("GetQuotations");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Error updating the product.");
                        }
                    }
                }
                catch (HttpRequestException ex)
                {
                    ModelState.AddModelError(string.Empty, $"Request error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"An error occurred: {ex.Message}");
                }
            }

            return View(qr);
        }




        [HttpGet]
        public async Task<ActionResult> DeleteQuotation(int id)
        {
            Quotation p = new Quotation();
            using (var httpClient = new HttpClient())
            using (var response = await httpClient.DeleteAsync($"http://localhost:9279/api/Quotations/{id}"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                p = JsonConvert.DeserializeObject<Quotation>(apiResponse);
                return RedirectToAction("GetQuotations");
            }
        }
        public async Task<ActionResult> GetInventries()
        {
            List<Tech_FIX_API.Models.Inventory> reservationList = new List<Tech_FIX_API.Models.Inventory>();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:1217/api/Inventories"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    reservationList = JsonConvert.DeserializeObject<List<Inventory>>(apiResponse);
                }
            }
            return View(reservationList);
        }



    }
}