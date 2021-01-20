using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Web.Data.Entities;

namespace Web.Application.MEvent
{
   public interface IEventService
    {
        public Task<int> Create(EventRequest request);
        public Task<int> Update(EventRequest request);
        public Task<Event> Details(Guid? id);
        public Task<int> Delete(EventRequest request);
        public Task<List<EventResponse>> GetAll();
        public Task<Event> FindById(Guid? id);
    }
}
