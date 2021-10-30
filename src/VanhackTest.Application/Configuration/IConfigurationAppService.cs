using System.Threading.Tasks;
using VanhackTest.Configuration.Dto;

namespace VanhackTest.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
