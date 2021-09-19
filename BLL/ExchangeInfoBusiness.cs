using BLL.Abstraction;
using DAL.Abstraction;
using Entities;

namespace BLL
{
    public class ExchangeInfoBusiness : BaseBusiness<ExchangeInfo>
    {
        public ExchangeInfoBusiness(IRepository<ExchangeInfo> _repository) : base(_repository)
        {
        }
    }
}