using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProEventos.Domain;
using ProEventos.Persistence.Contextos;
using ProEventos.Persistence.Contratos;

namespace ProEventos.Persistence
{
    public class PalestrantePersist : IPalestrantePersist
    {
        private readonly ProEventosContext conext;
        //Construtor
        public PalestrantePersist(ProEventosContext conext)
        {
            this.conext = conext;

        }
        public async Task<Palestrante[]> GetAllPalestrantesAsync(bool includeEventos = false)
        {
            IQueryable<Palestrante> query = this.conext.Palestrantes
               .Include(p => p.RedeSociais);

            if(includeEventos)
            {
                query = query
                        .Include(p => p.PalestranteEventos)
                        .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(p => p.Id);

            return await query.ToArrayAsync();
        } 
        public async Task<Palestrante[]> GetAllPalestrantesByNomeAsync(string nome, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = this.conext.Palestrantes
               .Include(p => p.RedeSociais);

            if(includeEventos)
            {
                query = query
                        .Include(p => p.PalestranteEventos)
                        .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(p => p.Id)
                         .Where(p => p.Nome.ToLower().Contains(nome.ToLower()));

            return await query.ToArrayAsync();
        }   

        public async Task<Palestrante> GetPalestranteByIdAsync(int palestranteId, bool includeEventos = false)
        {
            IQueryable<Palestrante> query = this.conext.Palestrantes
               .Include(p => p.RedeSociais);

            if(includeEventos)
            {
                query = query
                        .Include(p => p.PalestranteEventos)
                        .ThenInclude(pe => pe.Evento);
            }

            query = query.OrderBy(p => p.Id)
                         .Where(p => p.Id == palestranteId);

            return await query.FirstOrDefaultAsync();
        }

    }
}