using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.DAOs;
using Backend.Modelos;
using Backend.Seguridad;

namespace Frontend
{
    public partial class FrmRegistroUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            serverError.Visible = false;
            if (!IsPostBack)
            {
                ddlCarrera.DataSource = new CarreraDAO().ObtenerCarreras();
                ddlCarrera.DataValueField = "NombreCarrera";
                ddlCarrera.DataTextField = "NombreCarrera";
                ddlCarrera.DataBind();
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            var keys = new string[]
            {
                txtNombre.Text,
                txtPaterno.Text,
                txtMaterno.Text,
                txtCorreo.Text,
                txtContra.Text,
                txtContraConfirm.Text
            };

            if (Validador.Valida(keys, 2))
            {
                var usuario = new Usuario
                {
                    NombreUsuario = txtNombre.Text,
                    PaternoUsuario = txtPaterno.Text,
                    MaternoUsuario = txtMaterno.Text,
                    CorreoUsuario = txtCorreo.Text,
                    ContraUsuario = txtContra.Text,
                    CarreraUsuarioString = ddlCarrera.SelectedItem.Value,
                    TipoUsuarioString = ddlTipo.SelectedItem.Value
                };

                if (new UsuarioDAO().Insertar(usuario))
                {
                    Response.Redirect("Default.aspx");
                }
                else
                {
                    serverError.Visible = true;
                }
            }
            else
            {
                serverError.InnerText = "Los datos se modificaron y ya no son válidos";
                serverError.Visible = true;
            }
        }
    }
}