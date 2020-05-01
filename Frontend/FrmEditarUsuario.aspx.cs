using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.Modelos;
using Backend.DAOs;
using Backend.Seguridad;

namespace Frontend
{
    public partial class FrmEditarUsuario : System.Web.UI.Page
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
                if (Request["id_usuario"] != null)
                {
                    IdUsuario.Value = Request["id_usuario"].ToString();
                    var usuario = new UsuarioDAO().ObtenerUno(IdUsuario.Value.ToString());
                    if (usuario != null)
                    {
                        txtNombre.Text = usuario.NombreUsuario;
                        txtPaterno.Text = usuario.PaternoUsuario;
                        txtMaterno.Text = usuario.MaternoUsuario;
                        txtCorreo.Text = usuario.CorreoUsuario;
                        ddlCarrera.SelectedValue = usuario.CarreraUsuarioString.ToString();
                        ddlTipo.SelectedValue = usuario.TipoUsuarioString.ToString();
                    }
                    else
                    {
                        serverError.InnerText = "No se pudieron recuperar los datos";
                    }
                }
                else
                {
                    Response.Redirect("Default.aspx");
                }
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            var keys = new string[]
            {
                txtNombre.Text,
                txtPaterno.Text,
                txtMaterno.Text,
                txtCorreo.Text
            };

            if (Validador.Valida(keys, 4))
            {
                var usuario = new Usuario
                {
                    IdUsuario = IdUsuario.Value.ToString(),
                    NombreUsuario = txtNombre.Text,
                    PaternoUsuario = txtPaterno.Text,
                    MaternoUsuario = txtMaterno.Text,
                    CorreoUsuario = txtCorreo.Text,
                    CarreraUsuarioString = ddlCarrera.SelectedItem.Value,
                    TipoUsuarioString = ddlTipo.SelectedItem.Value
                };

                if (new UsuarioDAO().Actualizar(usuario))
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