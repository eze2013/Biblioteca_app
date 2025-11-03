using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Generic; // Para usar List<T>
using Biblioteca.Negocio;
// Asegúrate de incluir el 'using' para tus clases de Modelos (Autor, Pais)
// using Biblioteca.Modelos; 

namespace Biblioteca.Web // Asegúrate de que este Namespace coincida con el de tu proyecto
{
    // La clase debe heredar de Page
    public partial class ConsultaAutores : Page
    {
        // 1. DEPENDENCIA: Propiedad que usa el Service Locator (Global.GetInstance)
        // para obtener la instancia de la capa de negocio.
        public IAutorBLL AutorBLL
        {
            get
            {
                // Obtenemos la instancia inyectada y lista para usar.
                return (IAutorBLL)Global.GetInstance(typeof(IAutorBLL));
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            // Solo carga los datos cuando la página se carga por primera vez
            if (!IsPostBack)
            {
                CargarPaises();
            }
        }

        // 2. Método para cargar el DropDownList de Países
        private void CargarPaises()
        {
            try
            {
                // **NOTA IMPORTANTE:** Este método debe existir en IAutorBLL y AutorBLL
                var listaPaises = AutorBLL.ListarTodosLosPaises();

                ddlPaises.DataSource = listaPaises;
                ddlPaises.DataValueField = "Id"; // Propiedad que actúa como valor interno
                ddlPaises.DataTextField = "Nombre";  // Propiedad que se muestra al usuario
                ddlPaises.DataBind();

                // Añade la opción por defecto (Seleccione...)
                ddlPaises.Items.Insert(0, new ListItem("-- Seleccione --", "0"));

            }
            catch (Exception ex)
            {
                // Muestra cualquier error de carga en la etiqueta Literal
                litMensaje.Text = $"<div class='alert alert-danger'>Error al cargar países: {ex.Message}</div>";
            }
        }

        // 3. Método que se ejecuta al hacer clic en el botón "Consultar Autores"
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            litMensaje.Text = string.Empty; // Limpia mensajes anteriores

            if (ddlPaises.SelectedValue == "0")
            {
                litMensaje.Text = "<div class='alert alert-warning'>Por favor, seleccione un país.</div>";
                gvAutores.DataSource = null; // Limpia la grilla
                gvAutores.DataBind();
                return;
            }

            try
            {
                int idSeleccionado = int.Parse(ddlPaises.SelectedValue);

                // **NOTA IMPORTANTE:** Este método debe existir en IAutorBLL y AutorBLL
                var listaAutores = AutorBLL.ListarAutoresPorPais(idSeleccionado);

                gvAutores.DataSource = listaAutores;
                gvAutores.DataBind();

                if (listaAutores == null || listaAutores.Count == 0)
                {
                    litMensaje.Text = $"<div class='alert alert-info'>No se encontraron autores para el país seleccionado.</div>";
                }
                else
                {
                    litMensaje.Text = $"<div class='alert alert-success'>Consulta exitosa. Se encontraron {listaAutores.Count} autores.</div>";
                }
            }
            catch (Exception ex)
            {
                litMensaje.Text = $"<div class='alert alert-danger'>Error al consultar autores: {ex.Message}</div>";
            }
        }
    }
}