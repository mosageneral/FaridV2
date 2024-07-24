using Abp.Application.Services;
using FaridV2.MultiTenancy.Dto;

namespace FaridV2.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

