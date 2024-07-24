using System.Threading.Tasks;
using Abp.Application.Services;
using FaridV2.Authorization.Accounts.Dto;

namespace FaridV2.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
