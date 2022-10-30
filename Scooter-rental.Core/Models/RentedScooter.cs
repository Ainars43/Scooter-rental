using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Scooter_rental.Core.Models
{
    public class RentedScooter : Entity
    {
        public int ScooterId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal? Fee { get; set; }
    }
}