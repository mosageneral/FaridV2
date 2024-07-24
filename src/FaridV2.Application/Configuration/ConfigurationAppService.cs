using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using FaridV2.Configuration.Dto;

namespace FaridV2.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : FaridV2AppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
