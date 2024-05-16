using Dtos.PartCategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dtos.PartDtos
{
    public class PartDto
    {
        public int PartId { get; set; }
        public string Name { get; set; }
        public int? CarId { get; set; }
        public int PartCategoryId { get; set; }
        public string PartTitle { get; set; }

        public ResultPartCategoryDto PartCategory { get; set; }
    }
}
