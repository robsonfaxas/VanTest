using System.Threading.Tasks;
using Abp.Application.Services;
using VanhackTest.Authorization.Accounts.Dto;

namespace VanhackTest.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
