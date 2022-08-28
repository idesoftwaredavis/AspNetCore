using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApiCRUD.Data;
using WebApiCRUD.Dtos;
using WebApiCRUD.Models;

namespace WebApiCRUD.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // localhost/api/Producto
    public class ProductoController : ControllerBase
    {
        private readonly IApiRepository _repo;

        // inyectaremos el repositorio
        public ProductoController(IApiRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get(){
            // recuperar los productos
            var productos = await _repo.GetProductosAsync();
            
            return Ok(productos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id){
            var producto = await _repo.GetProductoByIdAsync(id);
            if(producto == null){
                return NotFound("Producto no encontrado");
            }
            return Ok(producto);
        }


        [HttpGet("nombre/{nombre}")]
        public async Task<IActionResult> Get(string nombre){
            var producto = await _repo.GetProductoByNombreAsync(nombre);

            var productoDto = new ProductoToListDto();
            productoDto.Id = producto.Id;
            productoDto.Nombre = producto.Nombre;
            productoDto.Descripcion = producto.Descripcion;

            if(productoDto == null){
                return NotFound("Producto no encontrado");
            }
            return Ok(productoDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(ProductoCreateDto productoDto){
            var productoToCreate = new Producto();
            // data
            productoToCreate.Nombre = productoDto.Nombre;
            productoToCreate.Descripcion = productoDto.Descripcion;
            productoToCreate.Precio = productoDto.Precio;
            productoToCreate.FechaAlta = DateTime.Now;
            productoToCreate.Activo=true;

            _repo.Add(productoToCreate);
            if( await _repo.SaveAll()){
                return Ok(productoToCreate);
            }
            return BadRequest();
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Put (int id, ProductoUpdateDto productoDto){
            if(id != productoDto.Id){
                return BadRequest("Los Ids no coinciden");
            }
            // filtro llamando el metodo del repositorio, pasandole id como parametro
            var productoToUpdate = await _repo.GetProductoByIdAsync(productoDto.Id);

            // Si el producto no existe, retorna BadRequest.
            if(productoToUpdate == null){
                return BadRequest();
            }

            // realizamos el update a partir de productoToUpdate
            productoToUpdate.Descripcion = productoDto.Descripcion;
            productoToUpdate.Precio = productoDto.Precio;

            if(!await _repo.SaveAll()){
                return NoContent();
            }

            return Ok(productoToUpdate);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id){
            var producto = await _repo.GetProductoByIdAsync(id);

            if(producto == null){
                return NotFound("Producto no encontrado");
            }

            _repo.Delete(producto);
            if(!await _repo.SaveAll()){
                return BadRequest("No se pudo eliminar el producto");
            }

            return Ok("Producto Borrado");
        }

    }
}