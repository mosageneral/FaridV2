using System.Threading.Tasks;
using Abp.Application.Services;
using FaridV2.Sessions.Dto;

namespace FaridV2.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
