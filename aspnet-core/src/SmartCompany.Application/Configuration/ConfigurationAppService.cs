using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using SmartCompany.Configuration.Dto;

namespace SmartCompany.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : SmartCompanyAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
