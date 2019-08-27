using System.Threading.Tasks;
using Abp.Application.Services;
using SmartCompany.Sessions.Dto;

namespace SmartCompany.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
