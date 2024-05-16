using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObjects
{
    public record CarDtoForInsertion
    {
        //[Index(IsUnique = true)]
        public string? PlateNumber { get; init; }
        public string Brand { get; init; }
        public string Model { get; init; }
        public string Color { get; init; }
    }
}
