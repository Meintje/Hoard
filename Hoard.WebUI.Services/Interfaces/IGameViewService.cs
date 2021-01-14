using Hoard.WebUI.Services.ViewModels;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.Interfaces
{
    public interface IGameViewService
    {
        public Task<GameIndexViewModel> GetGameIndex();
    }
}
