using Microsoft.AspNetCore.Mvc;
using TodoApi.Models;

namespace TodoApi.Controllers
{   
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        [HttpGet]
        [Route("listar")]
        public IActionResult ListarCliente()
        {
            var clientes = new List<Cliente>
            {
                new Cliente
                {
                    id = "1",
                    correo = "correo@empresa.com",
                    edad = "38",
                    nombre = "wilson"
                },
                new Cliente
                {
                    id = "2",
                    correo = "correo02@empresa.com",
                    edad = "20",
                    nombre = "pepito"
                }
            };
            return Ok(clientes);
        }

        [HttpGet]
        [Route("listarxid")]
        public dynamic listarClientexId(string _id)
        {
            return new Cliente
            {
                id = _id,
                correo = "correo02@empresa.com",
                edad = "20",
                nombre = "abc"
            };
        }
        
        [HttpPost]
        [Route("guardar")]
        public dynamic GuardarCliente(Cliente cliente)
        {
            cliente.id = "3";
            
            return new
            {
                success = true,
                message = "cliente registrado",
                result = cliente
            };

        }
        
        [HttpPost]
        [Route("eliminar")]
        public dynamic EliminarCliente(Cliente cliente)
        {
            string token = Request.Headers.Where(x => x.Key == "Authorization").FirstOrDefault().Value;
            
            if (token != "wztoken")
            {
                return new 
                {
                    success = false,
                    message = "Token incorrecto",
                    result = ""
                };
            }
                
            
            return new
            {
                success = true,
                message = "cliente eliminado",
                result = cliente
            };

        }
    }
}
