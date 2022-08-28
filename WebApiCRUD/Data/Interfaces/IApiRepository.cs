using System.Threading.Tasks;
using System.Collections.Generic;

using WebApiCRUD.Models;

namespace WebApiCRUD.Data
{
    public interface  IApiRepository
    {
        // Agregar registros a nuestras entidades.
        // Es un metodo generico, donde recibe T generico , donde T es la entidad como tal.

        // contrato o clausulas donde se deben implementar cuando la interfaz sea implementada.
        void Add<T>(T entity) where T: class;

        void Delete<T>(T entity) where T: class;

        Task<bool> SaveAll();

        Task<IEnumerable<Usuario>> GetUsuariosAsync();

        Task<Usuario> GetUsuarioByIdAsync(int id);

        Task<Usuario> GetUsuarioByNombreAsync(string nombre);

        Task<IEnumerable<Producto>> GetProductosAsync();

        Task<Producto> GetProductoByIdAsync(int id);

        Task<Producto> GetProductoByNombreAsync(string nombre);

    }

}