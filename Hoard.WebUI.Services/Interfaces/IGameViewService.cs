using Hoard.WebUI.Services.ViewModels;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.Interfaces
{
    public interface IGameViewService
    {
        public Task<GameIndexViewModel> GetGameIndex();
        public Task<GameDetailsViewModel> GetGameDetails(int id);
        public Task<GameCreateUpdateViewModel> GetGameCreateUpdateData(int? id);
        public Task CreateGame(GameCreateUpdateViewModel gcuVM);
        public Task<PlaythroughCreateUpdateViewModel> GetPlaythroughCreateUpdateData(int? pdID, int? ordinalNumber);
    }
}
