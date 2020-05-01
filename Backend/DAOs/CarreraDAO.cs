using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Backend.DAOs
{
    public class CarreraDAO
    {
        XDocument xmldoc;
        string path = AppDomain.CurrentDomain.BaseDirectory + @"xml\Carreras.xml";
        public Object ObtenerCarreras()
        {
            xmldoc = XDocument.Load(path);
            var bind = xmldoc.Descendants("carrera").Select(carrera => new
            {
                NombreCarrera = carrera.Element("nombre_carrera").Value
            });
            return bind;
        }
    }
}
