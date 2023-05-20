using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SalesOnline.Web.Models.Responses;
using static System.Net.WebRequestMethods;

namespace SalesOnline.Web.Controllers
{
    public class ProductoController : Controller
    {
        private readonly IConfiguration configuration;
        private readonly ILogger<ProductoController> logger;
        private HttpClientHandler clientHandler = new HttpClientHandler();
        public ProductoController(IConfiguration configuration, 
                                  ILogger<ProductoController> logger)
        {
            this.configuration = configuration;
            this.logger = logger;
        }

        // GET: ProductoController
        public async Task<ActionResult> Index()
        {
            ProductoListResponse productoList = new ProductoListResponse();

            try
            {
                using (var httpclient = new HttpClient(this.clientHandler))
                {
                    var response = await httpclient.GetAsync("http://localhost:5062/api/Product");

                    if (response.IsSuccessStatusCode)
                    {
                        string resp = await response.Content.ReadAsStringAsync();

                        productoList = JsonConvert.DeserializeObject<ProductoListResponse>(resp);

                    }
                }
            }
            catch (Exception ex)
            {
                this.logger.Log(LogLevel.Error, ex.ToString());
            }


            return View(productoList.data);
        }

        // GET: ProductoController/Details/5
        public async Task<ActionResult> Details(int id)
        {
            ProductoGetResponse productoGet = new ProductoGetResponse();

            try
            {
                using (var httpclient = new HttpClient(this.clientHandler))
                {

                    var url = "http://localhost:5062/api/Product/" + id;

                    var response = await httpclient.GetAsync(url);

                    if (response.IsSuccessStatusCode)
                    {
                        string resp = await response.Content.ReadAsStringAsync();

                        productoGet = JsonConvert.DeserializeObject<ProductoGetResponse>(resp);

                    }
                }
            }
            catch (Exception ex)
            {
                this.logger.Log(LogLevel.Error, ex.ToString());
            }


            return View(productoGet.data);
        }

        // GET: ProductoController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductoController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ProductoController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductoController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ProductoController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
