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
    }
}