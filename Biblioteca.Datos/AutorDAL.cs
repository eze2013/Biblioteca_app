using System;
using System.Collections.Generic;
using System.Data.SqlClient; // Necesitamos esta librería para usar los objetos de SQL Server
using System.Linq;
using Biblioteca.Modelos;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Datos
{
    public class AutorDAL : IAutorDAL
    {
        private readonly string _cadenaConexion =
        "################";
        public List<Autor> ListarAutores()
        {
            // Creamos una lista vacía que llenaremos con objetos 'Autor'
            List<Autor> listaAutores = new List<Autor>();
            // Creamos los objetos para la conexión
            // Usamos 'using' para asegurar que la conexión se cierre correctamente incluso si hay errores
            using (SqlConnection conexion = new SqlConnection(_cadenaConexion))
            {
                // Comando SQL para obtener todos los autores
                string query = "SELECT AUT_Id, AUT_Nombre, AUT_Apellido, PAI_Id FROM BIB_Autor ORDER BY AUT_Apellido";

                using (SqlCommand comando = new SqlCommand(query, conexion))
                {
                    try
                    {
                        conexion.Open(); // Abrimos la conexión con la base de datos

                        // SqlDataReader nos permite leer los datos fila por fila
                        using (SqlDataReader lector = comando.ExecuteReader())
                        {
                            // Leemos cada fila que devuelve la consulta
                            while (lector.Read())
                            {
                                // 1. Creamos un nuevo objeto Autor
                                Autor autor = new Autor();

                                // 2. Mapeamos las columnas de la base de datos al objeto C#
                                autor.Id = lector.GetInt32(0);          // Columna 0: AUT_Id (INT)
                                autor.Nombre = lector.GetString(1);     // Columna 1: AUT_Nombre (NVARCHAR)
                                autor.Apellido = lector.GetString(2);   // Columna 2: AUT_Apellido (NVARCHAR)
                                autor.PaisId = lector.GetInt32(3);      // Columna 3: PAI_Id (INT)

                                // 3. Agregamos el objeto a la lista
                                listaAutores.Add(autor);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Si hay un error (ej. mala conexión), imprimimos un mensaje simple.
                        Console.WriteLine("Error al conectar o leer datos: " + ex.Message);
                    }
                } // El comando se desecha y limpia automáticamente
            } // La conexión se cierra automáticamente
            return listaAutores; // Devolvemos la lista llena o vacía
        }
    }
}
