using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Modelos;

namespace Biblioteca.Datos
{
    public interface IAutorDAL
    {
        // Métodos de Lectura
        List<Autor> ListarAutores();
        List<Pais> ObtenerTodosLosPaises();
        List<Autor> ListarAutoresPorPais(int idPais);
    }
}
