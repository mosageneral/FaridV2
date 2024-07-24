using System.Threading.Tasks;
using FaridV2.Configuration.Dto;

namespace FaridV2.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
