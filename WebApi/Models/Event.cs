using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Event
    {
        public int IdEvento { get; set; }
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }
        public string Poster { get; set; }
        public TimeSpan Hora { get; set; }
        public string IdUsuario { get; set; }
        public string Lugar { get; set; }
        public decimal Costo { get; set; }
        public bool EsNumerado { get; set; }
        public int Cupo { get; set; }
        public int IdDependencia { get; set; }
    }
}