using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web.Application.MEvent;

namespace Web.WebApp.Service.Event
{
    public class EventApiClient : IEventApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public EventApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<string> Create(EventRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            var response = await client.PostAsync("api/Event/Create", httpContent);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(EventRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            var response = await client.PostAsync("api/Event/Delete", httpContent);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Details(Guid? id)
        {
            var json = JsonConvert.SerializeObject(id);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            var response = await client.GetAsync("api/Event/"+id);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> FindById(Guid? id)
        {
            var json = JsonConvert.SerializeObject(id);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            var response = await client.GetAsync("api/Event/FindById/"+id);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetAll()
        {
            var json = JsonConvert.SerializeObject(null);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            var response = await client.GetAsync("api/Event");

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(EventRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            var response = await client.PostAsync("api/Event/Update", httpContent);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
