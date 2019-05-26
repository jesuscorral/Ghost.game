using Ghost.Model.Ghost;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ghost.Data.Interface
{
    public interface IGhostRepository
    {
        Task<IEnumerable<Word>> GetWordsAsync();

        Task<bool> SaveChangesAsync();
    }
}