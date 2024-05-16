using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObjects
{
    public record CarDtoForUpdate
    {
        public int CarId { get; set; }
        public string? PlateNumber { get; init; }
        public string Brand { get; init; }
        public string Model { get; init; }
        public string Color { get; init; }
    }
}
