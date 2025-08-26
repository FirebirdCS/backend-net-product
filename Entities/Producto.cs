using System.Text.Json.Serialization;

namespace WebApi.Entities
{
    public class Producto
    {
        public string ProductoId { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }
        public string CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}