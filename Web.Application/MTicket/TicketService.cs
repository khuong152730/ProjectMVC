using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Web.Data.DataContext;
using Web.Data.Entities;

namespace Web.Application.MTicket
{
    public class TicketService : ITicketService
    {
        private readonly DataDbContext _context;
        public TicketService(DataDbContext context)
        {
            _context = context;
        }
        public async Task<int> Create(TicketRequest request)
        {
            var ticket = new Ticket()
            {
                name = request.name,
                hetmoban = request.hetmoban,
                gia = request.gia,
                toida = request.toida,
                giuphan = request.giuphan,
            
                EventId=request.EventId,
                Event =request.Event
            };
             _context.Tickets.Add(ticket);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> Delete(TicketRequest request)
        {
            var ticket = new Ticket()
            {
               id= request.id
            };
            _context.Tickets.Remove(ticket);
            return await _context.SaveChangesAsync();
        }

        public async Task<Ticket> Details(Guid? id)
        {
            return await _context.Tickets.FirstOrDefaultAsync(x => x.id == id);
        }

        public async Task<Ticket> FindById(Guid? id)
        {
            return await _context.Tickets.FindAsync(id);
        }

        public async Task<List<TicketReponse>> GetAll()
        {
            return await _context.Tickets.Select(x => new TicketReponse()
            {
                id = x.id,
                name = x.name,
                hetmoban = x.hetmoban,
                gia = x.gia,
                toida = x.toida,
                giuphan = x.giuphan,
                chuaxacnhan = x.chuaxacnhan,
                EventId =x.EventId,
                Event = x.Event
            }).ToListAsync();
        }
        public async Task<int> Update(TicketRequest request)
        {
            var ticket = new Ticket()
            {
                id =request.id,
                name = request.name,
                hetmoban = request.hetmoban,
                gia = request.gia,
                toida = request.toida,
                giuphan = request.giuphan,
                chuaxacnhan = request.chuaxacnhan,
                EventId = request.EventId,
                Event = request.Event
            };
            _context.Tickets.Update(ticket);
            return await _context.SaveChangesAsync();
        }
    }
}
