using System;
using System.Web;
using System.Web.UI;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using Biblioteca.Negocio;
using Biblioteca.Datos;

namespace Biblioteca.Web // Asegúrate de que este sea el namespace de tu proyecto
{
    public class Global : HttpApplication
    {
        private static Container container;

        void Application_Start(object sender, EventArgs e)
        {
            // 1. Inicialización y Lifestyle
            container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            // 2. Mapeo de Abstracción a Implementación
            container.Register<IAutorDAL, AutorDAL>(Lifestyle.Transient);
            container.Register<IAutorBLL, AutorBLL>(Lifestyle.Transient);

            // 3. Ya no necesitamos BuildUp, ni RegisterInitializer, ni PropertySelectionBehavior aquí.

            // 4. Verificación
            container.Verify();
        }

        // 5. Método GetInstance (ESTO ES AHORA NUESTRO "SERVICE LOCATOR")
        // Los code-behinds de las páginas lo llamarán directamente.
        public static object GetInstance(Type serviceType)
        {
            return container.GetInstance(serviceType);
        }

        // Nota: Hemos eliminado Application_PreRequestHandlerExecute
        // por completo para evitar el error CS1061.
    }
}