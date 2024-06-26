using AdapterPatternDemo.Models;
using System.Collections.Generic;

namespace AdapterPatternDemo.Interfaces
{
    public interface IProductoService
    {
        IEnumerable<Producto> ObtenerTodos();
        Producto ObtenerPorId(int id);
        void Crear(Producto producto);
        void Actualizar(Producto producto);
        void Eliminar(int id);
    }
}
