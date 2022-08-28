using Microsoft.EntityFrameworkCore;
using WebApiCRUD.Models;

namespace WebApiCRUD.Data
{
    /*
        EntityFrameWorkCore es un ORM, el cual nos ayudara
        pasar a objetos todo lo que tengamos en la base de datos (ViceVersa)

        CodeFirst: Primero hacer el codigo y luego lo llevamos a base de datos.

        DbContext : Nos ayudara a definir esas tablas que queremos que se creen en la base de datos
    */
    public class DataContext : DbContext{
        // En este constructor se realiza la inyeccion de dependencia
        public DataContext(DbContextOptions<DataContext> options) : base(options){ }


        // Para que entity framework los reconozca y los lleve hacia la base de datos, es necesario declarar nuestros modelos a partir de la clase DbSet.

        public DbSet<Producto> Productos {get;set;}
        public DbSet<Usuario> Usuarios {get;set;}


        /*
            Una instancia de dbcontext representa una sesion con la base de datos y se puede usar para consultar y guardar instancias de las entidades.

            dbcontext es una combinacion de los patrones de unidad de trabajo y repositorio.
            
        
        */
    }
}