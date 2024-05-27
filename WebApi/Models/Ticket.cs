using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.Models
{
    public class Ticket
    {
        public int IdRegistro { get; set; }
        public string CodigoQR { get; set; }
        public bool Asistencia { get; set; }
        public string Imagen { get; set; }
    }
}