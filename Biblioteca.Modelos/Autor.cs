using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Modelos
{
    public class Autor
    {
        // Corresponde a AUT_Id
        public int Id { get; set; }

        // Corresponde a AUT_Nombre
        public string Nombre { get; set; }

        // Corresponde a AUT_Apellido
        public string Apellido { get; set; }

        // Corresponde a PAI_Id
        public int PaisId { get; set; }
    }
}