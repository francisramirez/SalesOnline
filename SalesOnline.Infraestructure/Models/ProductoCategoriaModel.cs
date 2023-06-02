
using System.Collections.Generic;

namespace SalesOnline.Infraestructure.Models
{
    public class ProductoCategoriaModel
    {
        public ProductoCategoriaModel()
        {
            this.ProductoModel = new ProductoModel();
            this.CategoriaModels = new List<CategoriaModel>();
        }
        public ProductoModel? ProductoModel { get; set; }
        public List<CategoriaModel> CategoriaModels  { get; set; }
    }
}
