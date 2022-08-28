using System;

namespace WebApiCRUD.Dtos
{
    public class ProductoToListDto{
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
    }
}