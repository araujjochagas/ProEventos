using Microsoft.EntityFrameworkCore;
using ProEventos.api.Models;

namespace ProEventos.api.Data
{
    public class DataContext : DbContext
    {
       public DataContext(DbContextOptions<DataContext> options) : base(options) {  }
       public DbSet<Evento> Eventos { get; set; } 
    }
}