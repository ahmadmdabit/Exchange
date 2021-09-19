using Entities.Abstraction;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("exchange_infos")]
    public class ExchangeInfo : BaseEntity
    {
        public string Symbol { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal SalePrice { get; set; }
        public decimal StepSize { get; set; }
    }
}