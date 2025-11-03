using NUnit.Framework;
using Moq; // Librería de Mocking
using System.Collections.Generic;
using Biblioteca.Modelos; // IAutorDAL, Autor
using Biblioteca.Negocio;
using Biblioteca.Datos;


namespace Biblioteca.Negocio.Tests
{
    // 1. La clase de pruebas tiene el atributo [TestFixture]
    [TestFixture]
    public class AutorBLL_Tests
    {
        // 2. El método de prueba tiene el atributo [Test]
        [Test]
        public void ListarAutores_ListaDebeSerNoNulaYContarMasDeUno_RetornaListaConTres()
        {

            // Creamos una simulación (mock) de la Capa de Datos (IAutorDAL)
            var mockDAL = new Mock<IAutorDAL>();

            // Creamos la lista de 3 autores que el mock debe devolver
            var listaMock = new List<Autor>
            {
                new Autor { Id = 1, Nombre = "Autor 1" },
                new Autor { Id = 2, Nombre = "Autor 2" },
                new Autor { Id = 3, Nombre = "Autor 3" }
            };

            // DEVUELVE la lista simulada de 3 elementos, en lugar de ir a la BD.
            mockDAL.Setup(dal => dal.ListarAutores()).Returns(listaMock);
          
            // 1. Instanciamos la Capa de Negocio (AutorBLL), inyectándole el objeto mock (la simulación)
            var negocio = new AutorBLL(mockDAL.Object);

            // 2. Ejecutar el método a probar
            var resultado = negocio.ListarAutores();
             // Verificamos los requisitos del ejercicio:

            // Requisito 1: La lista de autores es NO NULA
            Assert.IsNotNull(resultado, "La lista de autores no debe ser nula.");

            // Requisito 2: La lista de autores tiene más de un elemento (debe tener 3, que es > 1)
            Assert.IsTrue(resultado.Count > 1, $"La lista debe tener más de 1 elemento, se encontró {resultado.Count}.");

            // Verificación extra (que todo funciona como se esperaba):
            Assert.AreEqual(3, resultado.Count, "El mock fue configurado para devolver exactamente 3 elementos.");
        }
    }
}
