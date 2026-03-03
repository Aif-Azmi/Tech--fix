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

namespace Tech_fix_Consumer_Admin.Controllers
{
    public class HomeController : Controller
    {

        //View and manage supplier details 
        public async Task<ActionResult> GetSuppliers()
        {
            List<Supplier> supplierList = new List<Supplier>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:9279/api/Suppliers"))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    supplierList = JsonConvert.DeserializeObject<List<Supplier>>(apiResponse);
                }
            }

            return View(supplierList);
        }

        //Add Suppliers
        public async Task<ActionResult> AddSupplier()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> AddSupplier(Supplier pr)
        {
            Supplier p = new Supplier();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(pr), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("http://localhost:9279/api/Suppliers", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    JsonConvert.DeserializeObject<Supplier>(apiResponse);
                }
            }
            return RedirectToAction("GetSuppliers");
        }

        public async Task<ActionResult> UpdateSupplier(string id)
        {
            Supplier pr = new Supplier();

            using (var httpClient = new HttpClient())
            {
                try
                {
                    using (var response = await httpClient.GetAsync($"http://localhost:9279/api/Suppliers/{id}"))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResponse = await response.Content.ReadAsStringAsync();
                            pr = JsonConvert.DeserializeObject<Supplier>(apiResponse);
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

            return View(pr);
        }

         [HttpPost]
        public async Task<ActionResult> UpdateSupplier(Supplier pr)
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
                    using (var response = await httpClient.PutAsync($"http://localhost:9279/api/Suppliers/{pr.SupplierID}", content))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            // Optionally, redirect or provide a success message
                            return RedirectToAction("GetSuppliers");
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
        public async Task<ActionResult> DeleteSupplier(int id)
        {
           Supplier p = new Supplier();
            using (var httpClient = new HttpClient())
            using (var response = await httpClient.DeleteAsync($"http://localhost:9279/api/Suppliers/{id}"))
            {
                string apiResponse = await response.Content.ReadAsStringAsync();
                p = JsonConvert.DeserializeObject<Supplier>(apiResponse);
                return RedirectToAction("GetSuppliers");
            }
        }

        //VIEW ALL QUOTATION
        public async Task<ActionResult> GetQuotation()
        {
            List<Quotation>erList = new List<Quotation>();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("http://localhost:9279/api/Quotations")) 
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    erList = JsonConvert.DeserializeObject<List<Quotation>>(apiResponse);
                }
            }

            return View(erList);
              
        }

        public async Task<ActionResult> AddOrder()
        {
            return View();
        }

        //ORDER QUOTATION 
        //----------------------
        [HttpPost]

        public async Task<ActionResult> AddOrder(Order pr)
        {
            Order p = new Order();
            using (var httpClient = new HttpClient())
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(pr), Encoding.UTF8, "application/json");
                using (var response = await httpClient.PostAsync("https://localhost:9279/api/Orders", content))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    JsonConvert.DeserializeObject<Order>(apiResponse);
                }
            }
            return RedirectToAction("GetQuotation");
        }





    }
}