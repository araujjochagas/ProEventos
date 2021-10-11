using System.Threading.Tasks;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class GeralPersist : IGeralPersist
    {
        private readonly ProEventosContext conext;

        //Construtor
        public GeralPersist(ProEventosContext conext)
        {
            this.conext = conext;

        }
        public void Add<T>(T entity) where T : class
        {
           this.conext.Add(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            this.conext.Update(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            this.conext.Remove(entity);
        }

        public void DeleteRange<T>(T[] entityarray) where T : class
        {
            this.DeleteRange(entityarray);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await this.conext.SaveChangesAsync())> 0;
        }
       
    }
}