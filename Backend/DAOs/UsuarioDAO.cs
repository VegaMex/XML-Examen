using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Web;
using Backend.Modelos;
using Backend.Seguridad;

namespace Backend.DAOs
{
    public class UsuarioDAO
    {
        XDocument xmldoc;
        string path = AppDomain.CurrentDomain.BaseDirectory + @"xml\Usuarios.xml";
        public Object Obtener()
        {
            xmldoc = XDocument.Load(path);
            var bind = xmldoc.Descendants("usuario").Select(usuario => new
            {
                IdUsuario = usuario.Element("id_usuario").Value,
                NombreUsuario = usuario.Element("nombre_usuario").Value,
                PaternoUsuario = usuario.Element("paterno_usuario").Value,
                MaternoUsuario = usuario.Element("materno_usuario").Value,
                CorreoUsuario = usuario.Element("correo_usuario").Value,
                ContraUsuario = usuario.Element("contra_usuario").Value,
                CarreraUsuarioString = usuario.Element("carrera_usuario").Value,
                TipoUsuarioString = usuario.Element("tipo_usuario").Value,
                NombreCompletoUsuario = string.Format("{0} {1} {2}", usuario.Element("nombre_usuario").Value, usuario.Element("paterno_usuario").Value, usuario.Element("materno_usuario").Value)
            }).OrderBy(usuario => usuario.IdUsuario);
            return bind;
        }

        public bool Insertar(Usuario usuario)
        {
            try
            {
                xmldoc = XDocument.Load(path);
                var count = xmldoc.Descendants("usuario").Count();
                XElement element = new XElement("usuario",
                               new XElement("id_usuario", count + 1),
                               new XElement("nombre_usuario", usuario.NombreUsuario),
                               new XElement("paterno_usuario", usuario.PaternoUsuario),
                               new XElement("materno_usuario", usuario.MaternoUsuario),
                               new XElement("correo_usuario", usuario.CorreoUsuario),
                               new XElement("contra_usuario", usuario.ContraUsuario),
                               new XElement("carrera_usuario", usuario.CarreraUsuarioString),
                               new XElement("tipo_usuario", usuario.TipoUsuarioString));
                xmldoc.Root.Add(element);
                xmldoc.Save(path);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Eliminar(string id_usuario)
        {
            try
            {
                xmldoc = XDocument.Load(path);
                XElement element = xmldoc.Descendants("usuario").FirstOrDefault(p => p.Element("id_usuario").Value == id_usuario);
                if (element != null)
                {
                    element.Remove();
                    xmldoc.Save(path);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public bool Actualizar(Usuario usuario)
        {
            xmldoc = XDocument.Load(path);
            XElement element = xmldoc.Descendants("usuario").FirstOrDefault(p => p.Element("id_usuario").Value == usuario.IdUsuario);
            if (element != null)
            {
                try
                {
                    element.Element("id_usuario").Value = usuario.IdUsuario;
                    element.Element("nombre_usuario").Value = usuario.NombreUsuario;
                    element.Element("paterno_usuario").Value = usuario.PaternoUsuario;
                    element.Element("materno_usuario").Value = usuario.MaternoUsuario;
                    element.Element("correo_usuario").Value = usuario.CorreoUsuario;
                    element.Element("carrera_usuario").Value = usuario.CarreraUsuarioString;
                    element.Element("tipo_usuario").Value = usuario.TipoUsuarioString;
                    xmldoc.Save(path);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }

        public bool NuevaContra(string id_usuario, string nueva_contra)
        {
            xmldoc = XDocument.Load(path);
            XElement element = xmldoc.Descendants("usuario").FirstOrDefault(p => p.Element("id_usuario").Value == id_usuario);
            if (element != null)
            {
                try
                {
                    element.Element("contra_usuario").Value = Password.ObtenerHash(nueva_contra);
                    xmldoc.Save(path);
                    return true;
                }
                catch
                {
                    return false;
                }
            }
            return false;
        }
    }
}