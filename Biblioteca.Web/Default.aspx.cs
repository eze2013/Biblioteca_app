using System;
using System.Web.UI;
using Biblioteca.Negocio;

// Asegúrate de que este namespace coincida con el nombre de tu proyecto web
namespace Biblioteca.Web
{
    public partial class _Default : Page
    {
        // NO USAMOS [Import]. Usamos una propiedad de solo lectura que llama a GetInstance.
        public IAutorBLL AutorBLL
        {
            get
            {
                // ESTA ES LA CLAVE: El Service Locator llama al contenedor global
                // para pedir la instancia de IAutorBLL.
                return (IAutorBLL)Global.GetInstance(typeof(IAutorBLL));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // La propiedad AutorBLL se evalúa aquí (llama al "get" de arriba)
                if (AutorBLL != null)
                {
                    try
                    {
                        // Intentamos usar la dependencia (esto prueba la conexión a la DB)
                        var autores = AutorBLL.ListarAutores();

                        // Si llegamos aquí, ¡todo funciona!
                        Response.Write("<h1>✅ ÉXITO DE INYECCIÓN Y CONEXIÓN</h1>");
                        Response.Write($"<p>El objeto IAutorBLL se obtuvo correctamente. Autores encontrados: <b>{autores.Count}</b></p>");
                    }
                    catch (Exception ex)
                    {
                        // Error si el objeto se obtiene, pero falla la DB
                        Response.Write("<h1>❌ ERROR DE CONEXIÓN A BASE DE DATOS</h1>");
                        Response.Write($"<p>La inyección de dependencias funcionó, pero falló al listar autores. Mensaje: {ex.Message}</p>");
                    }
                }
                else
                {
                    // Error si la inicialización en Global.asax.cs falló
                    Response.Write("<h1>❌ ERROR CRÍTICO DE INICIALIZACIÓN</h1>");
                    Response.Write("<p>El contenedor no pudo devolver la instancia de AutorBLL.</p>");
                }
            }
        }
    }
}