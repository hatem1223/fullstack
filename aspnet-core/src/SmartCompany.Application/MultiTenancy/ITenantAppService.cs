using Abp.Application.Services;
using Abp.Application.Services.Dto;
using SmartCompany.MultiTenancy.Dto;

namespace SmartCompany.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

