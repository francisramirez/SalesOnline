namespace SalesOnline.Web.Models.Responses
{
    public class ObtenerTokenResponse : ResponseBase
    {
        public TokenInfo data { get; set; }
    }
    public class TokenInfo 
    {
        public string? token { get; set; }
        public DateTime fechaexpiracion { get; set; }
    }
}
