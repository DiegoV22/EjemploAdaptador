using AdapterPatternDemo.Interfaces;
using AdapterPatternDemo.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AdapterPatternDemo.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IProductoService _productoService;

        public ProductosController(IProductoService productoService)
        {
            _productoService = productoService;
        }

        public IActionResult Index()
        {
            var productos = _productoService.ObtenerTodos().ToList();
            return View(productos);
        }

        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Crear(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _productoService.Crear(producto);
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        public IActionResult Editar(int id)
        {
            var producto = _productoService.ObtenerPorId(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(Producto producto)
        {
            if (ModelState.IsValid)
            {
                _productoService.Actualizar(producto);
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }
        public IActionResult Eliminar(int id)
        {
            var producto = _productoService.ObtenerPorId(id);
            if (producto == null)
            {
                return NotFound();
            }

            _productoService.Eliminar(id); // Pasar el id del producto

            return RedirectToAction(nameof(Index));
        }



    }
}
