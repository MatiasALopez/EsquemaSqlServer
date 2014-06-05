using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace EsquemaSqlServer
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LimpiarMensaje();

            try
            {
                if (!IsPostBack)
                    CargarComboColecciones();
            }
            catch (Exception ex)
            {
                MostrarMensaje(ex.Message);
            }
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

        private void CargarComboColecciones()
        {
            ddlNombreColeccion.Items.Clear();
            ddlNombreColeccion.Items.Add(System.Data.SqlClient.SqlClientMetaDataCollectionNames.Columns);
            ddlNombreColeccion.Items.Add(System.Data.SqlClient.SqlClientMetaDataCollectionNames.Databases);
            ddlNombreColeccion.Items.Add(System.Data.SqlClient.SqlClientMetaDataCollectionNames.ForeignKeys);
            ddlNombreColeccion.Items.Add(System.Data.SqlClient.SqlClientMetaDataCollectionNames.IndexColumns);
            ddlNombreColeccion.Items.Add(System.Data.SqlClient.SqlClientMetaDataCollectionNames.Indexes);
            //ddlNombreColeccion.Items.Add(System.Data.SqlClient.SqlClientMetaDataCollectionNames.Parameters);
            //ddlNombreColeccion.Items.Add(System.Data.SqlClient.SqlClientMetaDataCollectionNames.ProcedureColumns);
            ddlNombreColeccion.Items.Add(System.Data.SqlClient.SqlClientMetaDataCollectionNames.Procedures);
            ddlNombreColeccion.Items.Add(System.Data.SqlClient.SqlClientMetaDataCollectionNames.Tables);
            ddlNombreColeccion.Items.Add(System.Data.SqlClient.SqlClientMetaDataCollectionNames.UserDefinedTypes);
            ddlNombreColeccion.Items.Add(System.Data.SqlClient.SqlClientMetaDataCollectionNames.Users);
            ddlNombreColeccion.Items.Add(System.Data.SqlClient.SqlClientMetaDataCollectionNames.ViewColumns);
            ddlNombreColeccion.Items.Add(System.Data.SqlClient.SqlClientMetaDataCollectionNames.Views);
        }

        private void MostrarDatos()
        {
            var sqlSchema = new SqlServerSchema(txtConnectionString.Text);

            gvDatos.Visible = false;
            gvDatos.DataSource = sqlSchema.ObtenerDatos(ddlNombreColeccion.SelectedValue);
            gvDatos.DataBind();
            gvDatos.Visible = true;
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