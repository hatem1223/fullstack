using System.Threading.Tasks;
using SmartCompany.Configuration.Dto;

namespace SmartCompany.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
