using Microsoft.EntityFrameworkCore;
using bitacora.API.Models;


namespace bitacora.API.Data
{
     public class DataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Bitacora> Bitacoras { get; set; }
        public DataContext(DbContextOptions<DataContext>options):base(options)
        {
            
        }
         protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new BitacoraMap());

           
            base.OnModelCreating(modelBuilder);
        }
    }
}