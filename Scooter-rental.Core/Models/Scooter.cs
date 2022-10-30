using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Scooter_rental.Core.Models
{
    public class Scooter : Entity
    {
        [DefaultValue("false")]
        public bool IsRented { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal PricePerMinute { get; set; }
        
    }
}