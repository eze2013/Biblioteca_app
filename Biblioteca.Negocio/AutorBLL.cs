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

        // MÉTODOS DE ESCRITURA
        //public int InsertarAutor(Autor autor)
        //{
            // Aquí iría la validación de negocio
            //if (string.IsNullOrEmpty(autor.Nombre) || string.IsNullOrEmpty(autor.Apellido))
            //{
              //  throw new Exception("El nombre y apellido del autor son obligatorios.");
            //}
            //return _autorDAL.InsertarAutor(autor);
        //}

        //public int ActualizarAutor(Autor autor)
        //{
           // return _autorDAL.ActualizarAutor(autor);
        //}

        //public int EliminarAutor(int idAutor)
        //{
           // return _autorDAL.EliminarAutor(idAutor);
        //}
    }
}

