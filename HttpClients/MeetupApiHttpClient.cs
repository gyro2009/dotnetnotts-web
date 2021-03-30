using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Meetup.Api;

namespace dotnetnotts_web.HttpClients
{
    public class MeetupApiHttpClient
    {
        private readonly HttpClient _httpClient;

        public MeetupApiHttpClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Event> GetCurrentEvent()
        { 
            var result = await _httpClient.GetAsync("/api/events/next");

            if (!result.IsSuccessStatusCode) 
                return null;
            
            var events = await result.Content.ReadFromJsonAsync<Events>();

            return events?.results.FirstOrDefault();
        }
    }
}