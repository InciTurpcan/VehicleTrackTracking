using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class PartCategory
    {
        public int PartCategoryId { get; set; }
        public string PartCategoryName { get; set;}
        public List<Part> Parts { get; set; }

    }
}
