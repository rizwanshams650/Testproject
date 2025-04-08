using Testproject.Models;

namespace Testproject.Services
{
    public class PostService(HttpClient httpClient)
    {
        public async Task<List<Post>> GetPostsAsyncs()
        {
            return await httpClient.GetFromJsonAsync<List<Post>>("https://jsonplaceholder.typicode.com/posts");
        }

    }
}
