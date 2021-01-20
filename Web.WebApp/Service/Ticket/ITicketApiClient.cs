using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Application.MTicket;

namespace Web.WebApp.Service.Ticket
{
  public   interface ITicketApiClient
    {
        public Task<string> GetAll();

        public Task<string> Create(TicketRequest request);

        public Task<string> Update(TicketRequest request);

        public Task<string> Delete(TicketRequest request);

        public Task<string> Details(Guid? id);

        public Task<string> FindById(Guid? id);
    }
}
