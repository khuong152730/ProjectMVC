using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Web.Application.MTicket;

namespace Web.WebApp.Service.Ticket
{
    public class TicketApiClient : ITicketApiClient
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public TicketApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<string> Create(TicketRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            var response = await client.PostAsync("api/Ticket/Create", httpContent);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Delete(TicketRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            var response = await client.PostAsync("api/Ticket/Delete", httpContent);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Details(Guid? id)
        {
            var json = JsonConvert.SerializeObject(id);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            var response = await client.GetAsync("api/Ticket/"+id);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> FindById(Guid? id)
        {
            var json = JsonConvert.SerializeObject(id);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            var response = await client.GetAsync("api/Ticket/FindById/"+id);

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> GetAll()
        {
            var json = JsonConvert.SerializeObject(null);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            var response = await client.GetAsync("api/Ticket");

            return await response.Content.ReadAsStringAsync();
        }

        public async Task<string> Update(TicketRequest request)
        {
            var json = JsonConvert.SerializeObject(request);
            var httpContent = new StringContent(json, Encoding.UTF8, "application/json");

            var client = _httpClientFactory.CreateClient();
            client.BaseAddress = new Uri("https://localhost:5001");
            var response = await client.PostAsync("api/Ticket/Update", httpContent);

            return await response.Content.ReadAsStringAsync();
        }
    }
}
