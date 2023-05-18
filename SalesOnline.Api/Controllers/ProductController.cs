using Microsoft.AspNetCore.Mvc;
using SalesOnline.Application.Contract;
using SalesOnline.Application.Dtos.Producto;
using SalesOnline.Domain.Entities.Almacen;
using SalesOnline.Infraestructure.Exceptions;
using SalesOnline.Infraestructure.Interfaces;

namespace SalesOnline.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductoService productoService;

        public ProductController(IProductoService productoService)
        {
            this.productoService = productoService;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await this.productoService.Get();

            return Ok(products);
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.productoService.GetById(id);

            if (!result.Success)
                return BadRequest(result);


            return Ok(result);
            
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductAddDto productAddDto)
        {

            var result = await this.productoService.SaveProduct(productAddDto);

            if (!result.Success)
                return BadRequest(result);


            return Ok(result);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
