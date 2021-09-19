using DAL.Abstraction;
using DAL.DataContext;
using Entities;

namespace DAL
{
    public class UserRepository : BaseRepository<User, DatabaseContext>
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
        }
    }
}