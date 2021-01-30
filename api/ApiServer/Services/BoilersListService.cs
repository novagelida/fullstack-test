using System.Linq;
using System.Threading.Tasks;
using ApiServer.Controllers;
using ApiServer.Models;
using ApiServer.Models.Dto;
using LiteDB;


namespace ApiServer.Services
{
    public class BoilersListService : IBoilersListService
    {
        private readonly LiteDatabase db;

        public BoilersListService(LiteDatabase db)
        {
            this.db = db;
        }
        public async Task<PagedResults<Boiler>> GetAsync(PagingOptions pagingOptions)
        {
            var toReturn = await GetAsync();

            toReturn.Items = toReturn.Items.Skip(pagingOptions.Offset.Value).Take(pagingOptions.Limit.Value).ToList();

            return toReturn;
        }

        public async Task<PagedResults<Boiler>> GetAsync()
        {
            // The call to GetCollection is sync. If we want to use something different
            // than LiteDb, this call might be async
            var col = db.GetCollection<Boiler>("boilers");

            var list = col.Query().ToList();


            return new PagedResults<Boiler>()
            {
                Items = list,
                TotalSize = list.Count()
            };
        }
    }
}
