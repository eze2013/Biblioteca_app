using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Modelos;
using Biblioteca.Negocio;
using SimpleInjector;
using Biblioteca.Datos;


namespace Biblioteca.Presentacion
{
    class Program
    {
        private static readonly Container _container = new Container();
        static void Main(string[] args)
        {
            ConfigureContainer();   
            Console.WriteLine("--- Aplicación de Consola: Listado de Autores ---");
            Console.WriteLine(" ");
            IAutorBLL negocio = null;
            try
            {
                negocio = _container.GetInstance<IAutorBLL>();

                // 2. Llamar al método ListarAutores()
                // Esto inicia la cadena de ejecución: Presentación -> Negocio -> Datos -> SQL
                List<Autor> lista = negocio.ListarAutores();

                // 3. Verificar si la lista tiene datos (la conexión fue exitosa)
                if (lista.Count > 0)
                {
                    Console.WriteLine($"Se encontraron {lista.Count} autores en la base de datos:");
                    Console.WriteLine("------------------------------------------");

                    // 4. Recorrer y mostrar los datos
                    foreach (Autor autor in lista)
                    {
                        // Formato de salida: [ID] Apellido, Nombre (País ID: X)
                        Console.WriteLine($"[{autor.Id}] {autor.Apellido}, {autor.Nombre} (País ID: {autor.PaisId})");
                    }
                    Console.WriteLine("------------------------------------------");
                }
                else
                {
                    // Esto se mostraría si la lista está vacía (posiblemente por errores de conexión)
                    Console.WriteLine("No se encontraron autores o hubo un error al leer la base de datos.");
                    Console.WriteLine("Revisa la consola para ver posibles mensajes de error de conexión.");
                }
            }
            catch (Exception ex)
            {
                // Este catch atrapa cualquier error que la Capa de Negocio o Datos no hayan manejado
                Console.WriteLine("\n--- ERROR FATAL DE LA APLICACIÓN ---");
                Console.WriteLine($"Ocurrió un error inesperado: {ex.Message}");
            }
            // Esperamos una tecla para que la ventana de la consola no se cierre inmediatamente
            Console.WriteLine("\nPresione cualquier tecla para finalizar...");
            Console.ReadKey();
        }
        private static void ConfigureContainer()
        {
            // Mapeo de Abstracción a Implementación:

            // 1. Mapeo del Contrato DAL a su Implementación concreta (DAL)
            _container.Register<IAutorDAL, AutorDAL>(Lifestyle.Transient);

            // 2. Mapeo del Contrato BLL a su Implementación concreta (BLL)
            // SimpleInjector inyectará IAutorDAL automáticamente en el constructor de AutorBLL.
            _container.Register<IAutorBLL, AutorBLL>(Lifestyle.Transient);

            // 3. Opcional, pero vital para SimpleInjector:
            _container.Verify();
        }
    }
}
