using Microsoft.AspNetCore.Mvc;
using Tiendaapi.Datos;
using Tiendaapi.Modelo;

namespace Tiendaapi.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController
    {
        [HttpGet]
        public async Task <ActionResult<List<Mproductos>>> Get()
        {
            var funcion = new Dproductos();
            var lista = await funcion.MostrarProductos();
            return lista;
            
        }
    }
}
