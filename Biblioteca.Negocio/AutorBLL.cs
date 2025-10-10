using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Datos; // Necesitamos poder ver la Capa de Datos

namespace Biblioteca.Negocio
{
    public class AutorBLL
    {
        // En este método llamamos a la Capa de Presentación 
        public List<Autor> ListarAutores()
        {
            // Accedemos a los Datos 
            AutorDAL datos = new AutorDAL();

            // Llamamos al método de la Capa de Datos.
            return datos.ListarAutores();
        }
    }
}
