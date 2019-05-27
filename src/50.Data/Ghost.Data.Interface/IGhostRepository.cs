using Ghost.Model.Ghost;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ghost.Data.Interface
{
    public interface IGhostRepository
    {
        /// <summary>
        /// Return a list of word which start whit the letters passed as pameter
        /// </summary>
        /// <param name="startingWord">starting word to be searched</param>
        /// <returns>List of words</returns>
        Task<IEnumerable<Word>> GetWordsAsync(string startingWord);

        Task<bool> SaveChangesAsync();
    }
}