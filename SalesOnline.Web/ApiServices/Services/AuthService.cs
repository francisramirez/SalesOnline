using System.Text;
using Newtonsoft.Json;
using SalesOnline.Web.ApiServices.Interfaces;
using SalesOnline.Web.Models.Requests;
using SalesOnline.Web.Models.Responses;


namespace SalesOnline.Web.ApiServices.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpClientFactory clientFactory;
        private readonly IConfiguration configuration;
        private readonly ILogger<AuthService> logger;
        private readonly string baseUrl;
        public AuthService(IHttpClientFactory clientFactory,
                           IConfiguration configuration,
                           ILogger<AuthService> logger)
        {
            this.clientFactory = clientFactory;
            this.configuration = configuration;
            this.logger = logger;
            this.baseUrl = this.configuration["ApiConfig:urlBaseAuth"];
        }
        public async Task<CreateUserResponse> CreateUser(CreateUserRequest createUserRequest)
        {
            CreateUserResponse createUserResp = new CreateUserResponse();
            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/Auth/CrearUsuario";
                    StringContent request = new StringContent(JsonConvert.SerializeObject(createUserRequest), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(url, request))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResult = await response.Content.ReadAsStringAsync();
                            createUserResp = JsonConvert.DeserializeObject<CreateUserResponse>(apiResult);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                createUserResp.success = false;
                createUserResp.message = "Error creando el usuario.";
                this.logger.LogError($"{createUserResp.message}", ex.ToString());
            }
            return createUserResp;
        }
        public async Task<ObtenerTokenResponse> ObtenerTokenUsuario(ObtenerTokenRequest obtenerTokenRequest)
        {
            ObtenerTokenResponse obtenerToken = new ObtenerTokenResponse();

            try
            {
                using (var httpClient = this.clientFactory.CreateClient())
                {
                    string url = $" {this.baseUrl}/Auth/ObtenerTokenUsuario";
                    
                    StringContent request = new StringContent(JsonConvert.SerializeObject(obtenerTokenRequest), Encoding.UTF8, "application/json");

                    using (var response = await httpClient.PostAsync(url, request))
                    {
                        if (response.IsSuccessStatusCode)
                        {
                            string apiResult = await response.Content.ReadAsStringAsync();
                            obtenerToken = JsonConvert.DeserializeObject<ObtenerTokenResponse>(apiResult);

                        }
                    }
                }
            }
            catch (Exception ex)
            {

                obtenerToken.success = false;
                obtenerToken.message = "Error obteniendo el token.";
                this.logger.LogError($"{obtenerToken.message}", ex.ToString());
            }

            return obtenerToken;
        }
    }
}
