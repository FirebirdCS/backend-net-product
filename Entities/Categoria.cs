
using System.Text.Json.Serialization;

namespace WebApi.Entities
{
    public class Categoria
    {
        public string CategoriaId { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        [JsonIgnore]
        public virtual List<Producto> Productos { get; set; }
    }
}