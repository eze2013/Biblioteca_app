using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Modelos;

namespace Biblioteca.Negocio
{
    public interface IAutorBLL
    {
        // Métodos de Lectura
        List<Autor> ListarAutores();
        List<Pais> ListarTodosLosPaises();
        List<Autor> ListarAutoresPorPais(int idPais);
        // Métodos de Escritura (los que implementaste en la Tarea Opcional)
        //int InsertarAutor(Autor autor);
        //int ActualizarAutor(Autor autor);
        //int EliminarAutor(int idAutor);
    }
}
