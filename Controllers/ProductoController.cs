using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("v1/ProductoManagement/[controller]")]
    public class ProductoController : ControllerBase
    {
        private readonly TiendaDbContext DbContext;
        public ProductoController(TiendaDbContext _DbContext)
        {
            this.DbContext = _DbContext;
        }
        [HttpGet]
        public ActionResult<List<Producto>> Get()
        {
            var lista = DbContext.Producto.ToList();
            if (lista == null || lista.Count == 0)
            {
                return new NoContentResult();
            }
            return Ok(lista);
        }

        [HttpGet("{id}", Name = "GetProducto")]
        public async Task<ActionResult<Producto>> GetProducto(string id)
        {
            var producto = await DbContext.Producto.FirstOrDefaultAsync(p => p.ProductoId == id);
            if (producto == null)
            {
                return new NoContentResult();
            }
            return Ok(producto);
        }


        [HttpPost]
        public async Task<ActionResult<Producto>> Post([FromBody] Producto value)
        {
            value.ProductoId = Guid.NewGuid().ToString().ToUpper();
            await DbContext.Producto.AddAsync(value);
            await DbContext.SaveChangesAsync();
            return new CreatedAtRouteResult("GetProducto", new { id = value.ProductoId }, value);
        }

        [HttpDelete("{id}", Name = "DeleteProducto")]

        public async Task<ActionResult<Producto>> Delete(string id)
        {
            Producto producto = await DbContext.Producto.FirstOrDefaultAsync(p => p.ProductoId == id);
            if (producto == null)
            {
                return NotFound();
            }
            else
            {
                DbContext.Producto.Remove(producto);
                await DbContext.SaveChangesAsync();
                return producto;
            }
        }

        [HttpPut("{id}", Name = "UpdateProducto")]

        public async Task<ActionResult<Producto>> Put(string id, [FromBody] Producto value)
        {
            Producto producto = await DbContext.Producto.FirstOrDefaultAsync(p => p.ProductoId == id);
            if (producto == null)
            {
                return BadRequest();
            }
            producto.Nombre = value.Nombre;
            DbContext.Entry(producto).State = EntityState.Modified;
            await DbContext.SaveChangesAsync();
            return NoContent();
        }
    }
}