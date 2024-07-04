using System.Text.Json;
using TodoApi.DTOs;

namespace TodoApi.Services
{
    public class PostsService: IPostService
    {
        private HttpClient _httpClient;
        public PostsService(HttpClient HttpClient)
        {
            // como esta inyectado en el Program ya eliminamos esta inicializacion
            // y agregamos en la cabecera HttpClient
            // _httpClient = new HttpClient();
            _httpClient = HttpClient;
        }

        public async Task<IEnumerable<PostDto>> Get()
        {
            // como la url ya esta inyectada, no se necesita definir la url.
            // string url = "https://jsonplaceholder.typicode.com/posts";
            // var result = await _httpClient.GetAsync(url);

            // instanciamos BaseAddress donde esta la URL definido en Program
            var result = await _httpClient.GetAsync(_httpClient.BaseAddress);
            var body = await result.Content.ReadAsStringAsync();

            // para que los fields de PostDto sean en minusculas y pueda hacer match
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };

            // agregamos la configuracion para mostrar los campos en el listado
            var post = JsonSerializer.Deserialize<IEnumerable<PostDto>>(body, options);
            return post;
        }
    }
}