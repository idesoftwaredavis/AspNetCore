using System;

namespace WebApiCRUD.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string CorreoElectronico { get; set; }

        public DateTime FechaDeAlta { get; set; }

        public bool Activo { get; set; }
    }
}