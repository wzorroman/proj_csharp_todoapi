using TodoApi.DTOs;

namespace TodoApi.Services
{
    public interface IPostService
    {
        public Task<IEnumerable<PostDto>> Get();
    }
    
}