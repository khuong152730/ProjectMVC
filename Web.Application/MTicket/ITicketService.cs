using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.Data.Entities;

namespace Web.Application.MTicket
{
  public  interface ITicketService
    {
        public Task<int> Create(TicketRequest request);
        public Task<int> Update(TicketRequest request);
        public Task<int> Delete(TicketRequest request);
        public Task<List<TicketReponse>> GetAll();
        public Task<Ticket> Details(Guid? id);
        public Task<Ticket> FindById(Guid? id);
    }
}
