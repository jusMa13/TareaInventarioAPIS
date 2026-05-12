using Inventario.MODEL;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Inventario.SI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        // Istancia del gestor inventario 
        private readonly BL.GestorInventario _gestor;

        // Constructor del controlador con inyeccion de dependencias del gestor inventario
        public ProductsController(BL.GestorInventario gestor)
        {
            _gestor = gestor;
        }

        //Metodo lectura de productos   
        // GET: api/<ProductsController>
        [HttpGet]
        public IEnumerable<Producto> Get()
        {

            return _gestor.ObtenerProductos();
        }

        //Metodo lectura de producto por id
        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public ActionResult<Producto> Get(int id)
        {

            var producto = _gestor.ObtenerProductoPorId(id);
            if (producto == null)
            {
                return NotFound();




            }



            return producto;

        }
        //Metodo para agregar crear un nuevo producto
        // POST api/<ProductsController>
        [HttpPost]
        public ActionResult<Producto> Post([FromBody] Producto podructo)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _gestor.AgregarProducto(podructo);

            //  return Ok();
            return CreatedAtAction(nameof(Get), new { id = podructo.Id }, podructo);
        }

        //Metodo para actualizar un producto existente  
        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public ActionResult<Producto> Put(int id, [FromBody] Producto producto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _gestor.ActualizarProducto(producto);

            return Ok();

        }
        //Metodo para eliminar un producto por id   
        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public ActionResult<Producto> Delete(int id)
        {
            var producto = _gestor.ObtenerProductoPorId(id);
            if (producto == null)
            {
                return NotFound();
            }
            _gestor.EliminarProducto(id);

            return NoContent();
        }
    }
}
