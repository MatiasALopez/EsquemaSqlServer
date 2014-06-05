using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsquemaSqlServer
{
    public partial class Tablas : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void LimpiarMensaje()
        {
            panMensaje.Controls.Clear();
            panMensaje.Visible = false;
        }

        private void MostrarMensaje(string mensaje)
        {
            panMensaje.Controls.Add(new LiteralControl(mensaje));
            panMensaje.Visible = true;
        }

        private void MostrarDatos()
        {
            gvDatos.Visible = false;
            gvDatos.DataSource = ObtenerDatosColumnasDeTabla(txtNombreEsquema.Text, txtNombreTabla.Text); 
            gvDatos.DataBind();
            gvDatos.Visible = true;
        }

        private DataTable ObtenerDatosColumnasDeTabla(string esquema, string nombreTabla)
        {
            if (String.IsNullOrWhiteSpace(esquema))
                esquema = null;

            var sqlSchema = new SqlServerSchema(txtConnectionString.Text);
            var restricciones = new string[] { null, esquema, nombreTabla };

            return sqlSchema.ObtenerDatos(System.Data.SqlClient.SqlClientMetaDataCollectionNames.Columns, restricciones);
        }

        protected void btnObtener_Click(object sender, EventArgs e)
        {
            LimpiarMensaje();

            try
            {
                MostrarDatos();
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message);
            }
        }
    }
}