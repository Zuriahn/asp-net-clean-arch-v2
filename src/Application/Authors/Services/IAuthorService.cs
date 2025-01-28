
using Application.Authors.Dto;

namespace Application.Authors.Services 
{
    public interface IAuthorService 
    {
        Task<List<string>> GetAuthorsByNameAsync(string name);
    }
}