using ProEventos.Persistence.Contratos;
using ProEventos.Application.Contratos;
using System.Threading.Tasks;
using ProEventos.Domain;
using System;

namespace ProEventos.Application
{
    public class EventoService : IEventoService
    {
        private readonly IGeralPersist geralPersist;
        private readonly IEventoPersist eventoPersist;
        //Construtor
        public EventoService(IGeralPersist geralPersist, IEventoPersist eventoPersist)
        {
            this.eventoPersist = eventoPersist;
            this.geralPersist = geralPersist;

        }
        public async Task<Evento> AddEventos(Evento model)
        {
            try
            {
                this.geralPersist.Add<Evento>(model);
                if (await this.geralPersist.SaveChangesAsync())
                {//retorna valor do insert
                   return await this.eventoPersist.GetEventoByIdAsync(model.Id, false);
                }
                return null;
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
            
        }
        public async Task<Evento> UpdateEvento(int eventoId, Evento model)
        {
            try
            {
                var evento = await this.eventoPersist.GetEventoByIdAsync(eventoId, false);
                if(evento == null) return null;

                model.Id = evento.Id;

                this.geralPersist.Update(model);
                 if (await this.geralPersist.SaveChangesAsync())
                {//retorna valor do insert
                   return await this.eventoPersist.GetEventoByIdAsync(model.Id, false);
                }
                return null;                  
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteEvento(int eventoId)
        {
            try
            {
                var evento = await this.eventoPersist.GetEventoByIdAsync(eventoId, false);
                if(evento == null) throw new Exception("Evento Não Encotrado para Delete.");


                this.geralPersist.Delete<Evento>(evento);
                 return await this.geralPersist.SaveChangesAsync();
                          
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }
        }

        Task<Evento[]> IEventoService.GetAllEventosAsync(bool includePalestrantes)
        {
            throw new System.NotImplementedException();
        }

        Task<Evento[]> IEventoService.GetAllEventosByTemaAsync(bool includePalestrantes)
        {
            throw new System.NotImplementedException();
        }

        Task<Evento> IEventoService.GetEventoByIdAsync(int eventoId, bool includePalestrantes)
        {
            throw new System.NotImplementedException();
        }

       
    }
}