using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Modelos
{
    public interface IAutorDAL
    {
        // Métodos de Lectura
        List<Autor> ListarAutores();

        // Métodos de Escritura (los que implementaste en la Tarea Opcional)
        //int InsertarAutor(Autor autor);
        //int ActualizarAutor(Autor autor);
        //int EliminarAutor(int idAutor);
    }
}
