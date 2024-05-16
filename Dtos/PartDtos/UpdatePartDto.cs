using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.PartDtos
{
    public class UpdatePartDto
    {
        public int PartId { get; set; }
        public string Name { get; set; }
        public int CarId { get; set; }
        public int PartCategoryId { get; set; }
    }
}
