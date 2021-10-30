using System.Threading.Tasks;
using Abp.Application.Services;
using VanhackTest.Sessions.Dto;

namespace VanhackTest.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
