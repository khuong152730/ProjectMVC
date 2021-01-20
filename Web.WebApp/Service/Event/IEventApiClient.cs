using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Web.Application.MEvent;

namespace Web.WebApp.Service.Event
{
   public interface IEventApiClient
    {
        public Task<string> GetAll();

        public Task<string> Create(EventRequest request);

        public Task<string> Update(EventRequest request);

        public Task<string> Delete(EventRequest request);

        public Task<string> Details(Guid? id);

        public Task<string> FindById(Guid? id);
    }
}
