﻿using Microsoft.AspNetCore.Mvc;
using SalesOnline.Application.Contract;
using SalesOnline.Application.Dtos.Producto;


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
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await this.productoService.Get();

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await this.productoService.GetById(id);

            if (!result.Success)
                return BadRequest(result);


            return Ok(result);

        }


        [HttpGet("GetProductoCategoriaDetail")]
        public async Task<IActionResult> GetProductoCategoriaDetail(int id)
        {
            var result = await this.productoService.GetProductoCategoriaDetail(id);

            if (!result.Success)
                return BadRequest(result);


            return Ok(result);

        }
        [HttpGet("GetProductosByCategoria")]
        public async Task<IActionResult> GetProductosByCategoria(int categoriaId)
        {
            var result = await this.productoService.GetProductosByCategoria(categoriaId);

            if (!result.Success)
                return BadRequest(result);


            return Ok(result);

        }

        [HttpPost("SaveProduct")]
        public async Task<IActionResult> Post([FromBody] ProductAddDto productAddDto)
        {

            var result = await this.productoService.SaveProduct(productAddDto);

            if (!result.Success)
                return BadRequest(result);


            return Ok(result);
        }

        [HttpPost("UpdateProduct")]
        public async Task<IActionResult> Put([FromBody] ProductUpdateDto productUpdate)
        {
            var result = await this.productoService.ModifyProduct(productUpdate);

            if (!result.Success)
                return BadRequest(result);


            return Ok(result);
        }

    }
}
