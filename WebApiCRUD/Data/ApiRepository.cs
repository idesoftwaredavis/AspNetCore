using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiCRUD.Models;
using Microsoft.EntityFrameworkCore;
using System;
namespace WebApiCRUD.Data{
    public class ApiRepository : IApiRepository
    {
        private readonly DataContext _context;

        public ApiRepository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public async Task<Producto> GetProductoByIdAsync(int id)
        {
           // filtrado del producto a la base de datos a partir del id
           var producto = await _context.Productos.FirstOrDefaultAsync(p=> p.Id == id);
           Console.WriteLine(producto);
           return producto;
        }
        public async Task<Producto> GetProductoByNombreAsync(string nombre)
        {
            // filtrado del usuario a la base de datos a partir de su nombre
            var producto = await _context.Productos.FirstOrDefaultAsync(p => p.Nombre == nombre);
            return producto;
        }

        public async Task<IEnumerable<Producto>> GetProductosAsync()
        {
            // listado de productos a traves del DataContext de la entidad productos
            var productos = await _context.Productos.ToListAsync();
            return productos;
        }

        public async Task<Usuario> GetUsuarioByIdAsync(int id)
        {
            var user = await _context.Usuarios.FirstOrDefaultAsync(u => u.Id == id);
            return user;
        }

        public async Task<Usuario> GetUsuarioByNombreAsync(string nombre)
        {
            var userByName = await _context.Usuarios.FirstOrDefaultAsync(u=>u.Nombre==nombre);
            return userByName;
        }

        public async Task<IEnumerable<Usuario>> GetUsuariosAsync()
        {
            var users = await _context.Usuarios.ToListAsync();
            return users;
        }

        public async Task<bool> SaveAll()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}