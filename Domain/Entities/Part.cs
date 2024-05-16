using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Part
    {
        public int PartId { get; set; }
        public string Name { get; set; }
       
        public int? CarId { get; set; }
        public PartCategory PartCategory { get; set; }
        public int PartCategoryId { get; set; }
        
    }
}
