using HTTPClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HTTPClient.Services
{
    internal class PostServices
    {
        private HttpClient httpClient;
        private List<Post> posts;

        private JsonSerializerOptions JsonSerializerOptions;

        public PostServices()
        {
            httpClient = new HttpClient();
            JsonSerializerOptions = new JsonSerializerOptions{
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
            };
        }

        public async Task<List<Post>> GetPostsAsync() //Padronização de nome: Get + nome do recurso
        {
            Uri uri = new Uri("https://jsonplaceholder.typicode.com/posts");
            try
            {
                HttpReponseMessage response = await httpClient.GetAsync(uri);
                if (response.IsSucessStatusCode) { 
                    string content = await response.Content.ReadAsStringAsync}
                    posts = JsonSerializer.Deserialize<List<Post>>(content, JsonSerializerOptions)
            }
            catch
            {

            }
            return posts;
        }


    }
}
