using HTTPClient.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
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
        private Post post;
        private ObservableCollection<Post> posts;
        private JsonSerializerOptions JsonSerializerOptions;

        Uri uri = new Uri("https://jsonplaceholder.typicode.com/posts");

        public PostServices()
        {
            httpClient = new HttpClient();
            JsonSerializerOptions = new JsonSerializerOptions{
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
            };
        }

        public async Task<ObservableCollection<Post>> GetPostsAsync() //Padronização de nome: Get + nome do recurso
        {
            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    posts = JsonSerializer.Deserialize<ObservableCollection<Post>>(content, JsonSerializerOptions);
                }
            }
            catch
            {

            }
            return posts;
        }

        public async Task<Post> SavePostAsync(Post item)
        {
            try
            {
                string json = JsonSerializer.Serialize<Post>(item, JsonSerializerOptions);
                StringContent content = new StringContent(json, Encoding.UTF8, "aplication/json");
                HttpResponseMessage response = await httpClient.PostAsync(uri, content);

                if (response.IsSuccessStatusCode) {
                    Debug.WriteLine(response.Content);
                }
               
            }
            catch(Exception e)
            {
                Debug.WriteLine(e.Message);

            }
            return post;
        }


    }
}
