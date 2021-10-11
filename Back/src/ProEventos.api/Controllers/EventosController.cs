﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProEventos.Persistence;
using ProEventos.Domain;

namespace ProEventos.api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class EventosController : ControllerBase
    {
        private readonly ProEventosContext _context;

        public EventosController(ProEventosContext context)
        {
            this._context = context;

        }

        [HttpGet]
        public IEnumerable<Evento> Get()
        {
            return _context.Evento;
        }
        [HttpGet("{id}")]
        public Evento GetById(int id)
        {
            return _context.Evento.FirstOrDefault(
                    evento => evento.Id == id
            );
        }
    }
}
