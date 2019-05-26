using Ghost.Service.Interface.Request;
using Ghost.Service.Interface.Response;
using System.Threading.Tasks;

namespace Ghost.Service.Interface
{
    public interface IGhostService
    {
        Task<CheckWordResponse> CheckWordAsync(CheckWordRequest request);
    }
}
