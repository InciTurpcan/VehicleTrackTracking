using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.Contracts
{
    public interface IRepositoryManager
    {
        ICarRepository Car { get; }
        IPartRepository Part { get; }
        IPartCategoryRepository PartCategory { get; }
      
        void Save();
    }
}
