using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Datos; // Necesitamos poder ver la Capa de Datos
using Biblioteca.Modelos;

namespace Biblioteca.Negocio
{
    public class AutorBLL : IAutorBLL
    {
        // 1. Dependencia: Ahora dependemos del CONTRATO (IAutorDAL), no de la clase concreta (AutorDAL)
        private readonly IAutorDAL _autorDAL;

        // 2. Inyección de Dependencias por Constructor (DI)
        // El Contenedor DI llamará a este constructor y le pasará la implementación de IAutorDAL
        public AutorBLL(IAutorDAL autorDAL)
        {
            _autorDAL = autorDAL;
        }

        // MÉTODOS DE LECTURA
        public List<Autor> ListarAutores()
        {
            // Usamos la dependencia inyectada. ¡No hay new AutorDAL()!
            return _autorDAL.ListarAutores();
        }

        public List<Pais> ListarTodosLosPaises()
        {
            // Delegamos la llamada al DAL, que se encargará de la conexión y el SQL
            return _autorDAL.ObtenerTodosLosPaises();
        }

        public List<Autor> ListarAutoresPorPais(int idPais)
        {
            // Delegamos al DAL. El BLL solo verifica si la llamada tiene sentido.
            if (idPais <= 0)
            {
                // Ejemplo de una simple validación de negocio en el BLL
                throw new ArgumentException("El ID de País debe ser un valor positivo.");
            }
            return _autorDAL.ListarAutoresPorPais(idPais);
        }

    }
}

