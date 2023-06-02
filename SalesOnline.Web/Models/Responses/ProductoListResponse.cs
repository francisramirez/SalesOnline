namespace SalesOnline.Web.Models.Responses
{
    public class ProductoListResponse : ResponseBase
    {
        public List<ProductoModel>? data { get; set; }

    }

    public class ProductoGetResponse : ResponseBase
    {
        public ProductoModel? data { get; set; }

    }
}
