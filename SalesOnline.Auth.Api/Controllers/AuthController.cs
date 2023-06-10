using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesOnline.Application.Contract;
using SalesOnline.Application.Dtos.Usuario;
using SalesOnline.Application.Models;
using SalesOnline.Auth.Api.Core;
using SalesOnline.Infraestructure.Models.Usuario;

namespace SalesOnline.Auth.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioService usuarioService;
        private readonly IConfiguration configuration;
        public AuthController(IUsuarioService usuarioService, IConfiguration configuration)
        {
            this.usuarioService = usuarioService;
            this.configuration = configuration;
        }
        [HttpPost("CrearUsuario")]
        public async Task<IActionResult> CrearUsuario(UsaurioAddDto usaurioAdd) 
        {

            var result = await this.usuarioService.SaveUsuario(usaurioAdd);

            return Ok(result);
        }

        [HttpPost("ObtenerTokenUsuario")]
        public async Task<IActionResult> ObtenerTokenUsuario(GetUsuarioInfoDto getUsuarioInfoDto)
        {


            var result = await this.usuarioService.GetUsuario(getUsuarioInfoDto);


            if (result.Success)
            {
                UsuarioModel usuario = (UsuarioModel)result.Data;
               
                TokenInfo tokenInfo = TokenHelper.GetToken(usuario, 
                                                           this.configuration["TokenInfo:SiginigKey"]);

                result.Data = tokenInfo;

            }
            else
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

    }
}
