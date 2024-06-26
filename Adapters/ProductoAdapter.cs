using AdapterPatternDemo.Interfaces;
using AdapterPatternDemo.Models;
using AdapterPatternDemo.Services;
using System.Collections.Generic;

namespace AdapterPatternDemo.Adapters
{
    public class ProductoAdapter : IProductoService
    {
        private readonly ProductoService _productoService;

        public ProductoAdapter(ProductoService productoService)
        {
            _productoService = productoService;
        }

        public IEnumerable<Producto> ObtenerTodos()
        {
            return _productoService.ObtenerTodos();
        }

        public Producto ObtenerPorId(int id)
        {
            return _productoService.ObtenerPorId(id);
        }

        public void Crear(Producto producto)
        {
            _productoService.Crear(producto);
        }

        public void Actualizar(Producto producto)
        {
            _productoService.Actualizar(producto);
        }

        public void Eliminar(int id)
        {
            _productoService.Eliminar(id);
        }
    }
}
