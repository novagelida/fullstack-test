using ApiServer.Models;
using ApiServer.Models.Dto;
using System.Threading.Tasks;

namespace ApiServer.Services
{
    public interface IBoilersListService
    {
        Task<PagedResults<Boiler>> GetAsync(PagingOptions pagingOptions);

        Task<PagedResults<Boiler>> GetAsync();
    }
}