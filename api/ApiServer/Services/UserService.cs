using ApiServer.Models;
using ApiServer.Services.Interfaces;
using LiteDB;
using System.Threading.Tasks;

namespace ApiServer.Services
{
    public class UserService : IUserService
    {
        private readonly LiteDatabase db;

        public UserService(LiteDatabase db)
        {
            this.db = db;
        }

        public async Task<User> GetByIdAsync(int userId)
        {
            // The call to GetCollection is sync. If we want to use something different
            // than LiteDb, this call might be async
            var col = db.GetCollection<User>("users");

            return col.Query().Where(u => u.Id == userId).FirstOrDefault();
        }
    }
}
