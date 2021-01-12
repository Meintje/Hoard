using Hoard.WebUI.Services.ViewModels;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.Interfaces
{
    public interface IGameService
    {
        public GameIndexViewModel GetGameIndex();
    }
}
