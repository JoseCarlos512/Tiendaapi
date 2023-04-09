using System.Data;
using System.Data.SqlClient;
using Tiendaapi.Conexion;
using Tiendaapi.Modelo;

namespace Tiendaapi.Datos
{
    public class Dproductos
    {
        /** Conexion a la BD **/
        Conexionbd cn = new Conexionbd();

        /** Mostrar productos **/
        public async Task <List<Mproductos>> MostrarProductos()
        {
            var lista = new List<Mproductos>();
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                // Se conecta al procedure con SqlCommand
                using (var cmd = new SqlCommand("mostrarProductos", sql))
                {
                    // Como ya tiene listo la instancia el nombre del procedure
                    // Abre la conexion
                    await sql.OpenAsync();
                    // Ejecuta el procedure
                    cmd.CommandType = CommandType.StoredProcedure;

                    using(var item = await cmd.ExecuteReaderAsync()) 
                    { 
                        while(await item.ReadAsync())
                        {
                            var mproductos = new Mproductos();
                                mproductos.id = (int)item["id"];
                                mproductos.descripcion = (string)item["descripcion"];
                                mproductos.precio = (decimal)item["precio"];

                            lista.Add(mproductos);
                        }
                    }
                }
            }
            return lista;
        }

        /** Insertar productos **/
        public async Task InsertarProductos(Mproductos parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("insertarProductos", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("descripcion", parametros.descripcion);
                    cmd.Parameters.AddWithValue("precio", parametros.precio);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }


        /** Update productos **/
        public async Task UpdateProductos(Mproductos parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("editarProductos", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id", parametros.id);
                    cmd.Parameters.AddWithValue("precio", parametros.precio);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }

        /** Delete productos **/
        public async Task DeleteProductos(Mproductos parametros)
        {
            using (var sql = new SqlConnection(cn.cadenaSQL()))
            {
                using (var cmd = new SqlCommand("eliminarProductos", sql))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("id", parametros.id);

                    await sql.OpenAsync();
                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
