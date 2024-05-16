using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DataTransferObjects
{
    public record PartDtoForInsertion
    {
        public string Name { get; set; }        
        public int PartCategoryId { get; set; }
    }
}
