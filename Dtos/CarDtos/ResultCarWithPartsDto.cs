using Dtos.PartDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.CarDtos
{
    public class ResultCarWithPartsDto
    {
        public int CarId { get; set; }
        public string? PlateNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Color { get; set; }
        public List<PartDto> Parts { get; set; }
    }
}
