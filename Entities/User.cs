using Entities.Abstraction;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    [Table("users")]
    public class User : BaseEntity
    {
        public string Username { get; set; }

        [JsonIgnore]
        public string Password { get; set; }
    }
}