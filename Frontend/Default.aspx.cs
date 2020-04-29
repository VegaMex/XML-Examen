using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Backend.DAOs;

namespace Frontend
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UsuarioDAO dao = new UsuarioDAO();
            object c = dao.Obtener();
            UsuarioDAO y = null;
        }
    }
}