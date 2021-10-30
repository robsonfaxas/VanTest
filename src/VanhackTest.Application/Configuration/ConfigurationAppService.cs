using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using VanhackTest.Configuration.Dto;

namespace VanhackTest.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : VanhackTestAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
