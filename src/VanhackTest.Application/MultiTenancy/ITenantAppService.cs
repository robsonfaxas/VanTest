using Abp.Application.Services;
using VanhackTest.MultiTenancy.Dto;

namespace VanhackTest.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

