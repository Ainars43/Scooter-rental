using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scooter_rental.Core.Models
{
    public class Scooter : Entity
    {
        [Column(TypeName = "decimal(18,2)")]
        public decimal PricePerMinute { get; set; }
        public bool IsRented { get; set; }
    }
}