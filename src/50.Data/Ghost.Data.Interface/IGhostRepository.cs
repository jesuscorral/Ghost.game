using Ghost.Model.Ghost;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ghost.Data.Interface
{
    public interface IGhostRepository
    {
        IEnumerable<Word> GetWords();

        Task<bool> SaveChangesAsync();
    }
}