﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Backend.Modelos
{
    public class Usuario
    {
        public string IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string PaternoUsuario { get; set; }
        public string MaternoUsuario { get; set; }
        public string CorreoUsuario { get; set; }
        public string ContraUsuario { get; set; }
        public string CarreraUsuario { get; set; }
        public string TipoUsuario { get; set; }
    }
}
