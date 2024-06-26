using AdapterPatternDemo.Data;
using AdapterPatternDemo.Interfaces;
using AdapterPatternDemo.Models;
using System.Collections.Generic;
using System.Linq;

namespace AdapterPatternDemo.Services
{
    public class ProductoService : IProductoService
    {
        private readonly ApplicationDbContext _context;

        public ProductoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Producto> ObtenerTodos()
        {
            return _context.Productos.ToList();
        }

        public Producto ObtenerPorId(int id)
        {
            return _context.Productos.Find(id);
        }

        public void Crear(Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();
        }

        public void Actualizar(Producto producto)
        {
            _context.Productos.Update(producto);
            _context.SaveChanges();
        }

        public void Eliminar(int id)
        {
            var producto = _context.Productos.Find(id);
            if (producto != null)
            {
                _context.Productos.Remove(producto);
                _context.SaveChanges();
            }
        }
    }
}
