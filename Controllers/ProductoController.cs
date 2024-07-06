using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Producto.Models;

namespace Producto.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly ProductoContext _baseDatos;

        public ProductoController(ProductoContext baseDatos)
        {
            _baseDatos = baseDatos;
        }

        // Método para obtener la lista de todos los productos
        [HttpGet]
        [Route("ListaProductos")]
        public async Task<IActionResult> Lista()
        {
            var listaProductos = await _baseDatos.Productos.ToListAsync();
            return Ok(listaProductos);
        }

        // Método para obtener productos por idCategoria
        [HttpGet]
        [Route("ListaProductosPorCategoria/{idCategoria}")]
        public async Task<IActionResult> ListaProductosPorCategoria(int idCategoria)
        {
            var productosPorCategoria = await _baseDatos.Productos
                                                        .Where(p => p.IdCategoria == idCategoria)
                                                        .ToListAsync();
            if (productosPorCategoria == null || !productosPorCategoria.Any())
            {
                return NotFound(new { mensaje = "No se encontraron productos para esta categoría." });
            }
            return Ok(productosPorCategoria);
        }

        // Nuevo método para buscar productos por palabra clave
        [HttpGet]
        [Route("BuscarProductos/{palabraClave}")]
        public async Task<IActionResult> BuscarProductos(string palabraClave)
        {
            var productosEncontrados = await _baseDatos.Productos
                                                       .Where(p => p.Nombre.Contains(palabraClave) ||
                                                                   p.Modelo.Contains(palabraClave))
                                                       .ToListAsync();
            if (productosEncontrados == null || !productosEncontrados.Any())
            {
                return NotFound(new { mensaje = "No se encontraron productos que coincidan con la palabra clave." });
            }
            return Ok(productosEncontrados);
        }
    }
}
