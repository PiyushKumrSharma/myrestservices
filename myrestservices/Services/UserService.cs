using myrestservices.Models;
using Newtonsoft.Json;

namespace myrestservices.Services
{
    public interface IUserService
    {
        Task<User> GetRandomUserAsync();
    }

    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<User> GetRandomUserAsync()
        {
            var response = await _httpClient.GetAsync("https://randomuser.me/api/");
            response.EnsureSuccessStatusCode();
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<RandomUserResult>(json);
            return result?.Results[0];
        }

        private class RandomUserResult
        {
            public List<User>? Results { get; set; }
        }
    }
}
