using Microsoft.AspNetCore.Mvc;
using Tiendaapi.Datos;
using Tiendaapi.Modelo;

namespace Tiendaapi.Controllers
{
    [ApiController]
    [Route("api/productos")]
    public class ProductosController: ControllerBase
    {
        [HttpGet]
        public async Task <ActionResult<List<Mproductos>>> Get()
        {
            var funcion = new Dproductos();
            var lista = await funcion.MostrarProductos();
            return lista;
            
        }

        [HttpPost]
        public async Task Post([FromBody] Mproductos parametros)
        {
            var funcion = new Dproductos();
            await funcion.InsertarProductos(parametros);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] Mproductos parametros)
        {
            var funcion = new Dproductos();
            parametros.id = id;

            await funcion.UpdateProductos(parametros);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> delete(int id)
        {
            var funcion = new Dproductos();
            var parametros = new Mproductos();
            parametros.id = id;
            await funcion.DeleteProductos(parametros);
            return NoContent();
        }
    }
}
