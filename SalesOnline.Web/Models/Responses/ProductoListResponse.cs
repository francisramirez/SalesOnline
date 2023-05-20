namespace SalesOnline.Web.Models.Responses
{
    public class ProductoListResponse
    {
        public string? message { get; set; }
        public bool success { get; set; }
        public List<ProductoModel>? data { get; set; }

    }

    public class ProductoGetResponse
    {
        public string? message { get; set; }
        public bool success { get; set; }
        public ProductoModel? data { get; set; }

    }
}
