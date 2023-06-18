using Newtonsoft.Json;
using SalesOnline.Web.ApiServices.Interfaces;
using SalesOnline.Web.Models.Requests;
using SalesOnline.Web.Models.Responses;
using System.Text;

namespace SalesOnline.Web.ApiServices.Services
{
    public class ProductApiService : IProductApiService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<ProductApiService> logger;
        private readonly string baseUrl;
       

        private string _token;
       
        public ProductApiService(IHttpClientFactory clientFactory,
                                 IConfiguration configuration,
                                 ILogger<ProductApiService> logger)
        {
            this.clientFactory = clientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = this.configuration["ApiConfig:urlBase"];
            

        }

        public string Token 
        {
            get;
            set; 
             
        }

        public async Task<ProductoGetResponse> GetProducto(int Id)
        {
            ProductoGetResponse productoGet = new ProductoGetResponse();

            try
            {

                using (var httpClient = this.clientFactory.CreateClient())
                {



                    string url = $" {this.baseUrl}/Product/{Id}";

                    using (var response = await httpClient.GetAsync(url))
                    {

                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();

                            productoGet = JsonConvert.DeserializeObject<ProductoGetResponse>(resp);
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                productoGet.success = false;
                productoGet.message = this.configuration["ProductErrorMessage:GetProducto"];
                this.logger.LogError(productoGet.message, ex.ToString());

            }
            return productoGet;
        }

        public async Task<ProductoListResponse> GetProductos()
        {
            ProductoListResponse productoList = new ProductoListResponse();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/Product";

                    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer { this.Token }");
                    
                    using (var response = await httpClient.GetAsync(url))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string resp = await response.Content.ReadAsStringAsync();

                            productoList = JsonConvert.DeserializeObject<ProductoListResponse>(resp);
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                productoList.success = false;
                productoList.message = this.configuration["ProductErrorMessage:GetProductos"];
                this.logger.LogError(productoList.message, ex.ToString());
            }

            return productoList;
        }

        public async Task<ProductAddReponse> SaveProducto(ProductSaveRequest productRequest)
        {
            ProductAddReponse result = new ProductAddReponse();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/Product/SaveProduct";

                    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {this.Token}");

                    StringContent request = new StringContent(JsonConvert.SerializeObject(productRequest), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(url, request))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResult = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<ProductAddReponse>(apiResult);

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                result.success = false;
                result.message = this.configuration["ProductErrorMessage:Save"];
                this.logger.LogError(result.message, ex.ToString());
            }

            return result;
        }

        public async Task<ResponseBase> UpdateProducto(ProductSaveRequest productRequest)
        {
            ResponseBase result = new ResponseBase();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/Product/UpdateProduct";
                   
                    httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {this.Token}");

                    StringContent request = new StringContent(JsonConvert.SerializeObject(productRequest), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(url, request))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResult = await response.Content.ReadAsStringAsync();
                            result = JsonConvert.DeserializeObject<ResponseBase>(apiResult);

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                result.success = false;
                result.message = this.configuration["ProductErrorMessage:Update"];
                this.logger.LogError(result.message, ex.ToString());
            }

            return result;
        }
    }
}
