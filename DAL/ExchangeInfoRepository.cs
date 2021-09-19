using DAL.Abstraction;
using DAL.DataContext;
using Entities;

namespace DAL
{
    public class ExchangeInfoRepository : BaseRepository<ExchangeInfo, DatabaseContext>
    {
        public ExchangeInfoRepository(DatabaseContext context) : base(context)
        {
        }
    }
}