using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class User
    {
        public string IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int IdDependencia { get; set; }
        public string Telefono { get; set; }
        public string Correo { get; set; }
        public int IdRol {  get; set; }
    }
}