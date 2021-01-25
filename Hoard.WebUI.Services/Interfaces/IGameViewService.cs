using Hoard.WebUI.Services.ViewModels;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.Interfaces
{
    public interface IGameViewService
    {
        public Task<GameIndexViewModel> GetGameIndex();
        public Task<GameDetailsViewModel> GetGameDetails(int id);
        public Task<GameCreateViewModel> GetGameCreateData();
        public Task<GameUpdateViewModel> GetGameUpdateData(int id);
        public Task CreateGame(GameCreateViewModel gcVM);
        public Task UpdateGame(GameUpdateViewModel guVM);

        public Task<PlaythroughCreateUpdateViewModel> GetPlaythroughCreateUpdateData(int? pdID, int? ordinalNumber);
    }
}
