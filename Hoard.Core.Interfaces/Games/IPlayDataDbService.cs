using Hoard.Core.Entities.Games;
using System;
using System.Threading.Tasks;

namespace Hoard.Core.Interfaces.Games
{
    public interface IPlayDataDbService
    {
        public Task<PlayData> GetDetailsAsync(int id);
        public Task<PlayData> GetUpdateDataAsync(int id);
        public Task UpdateAsync(PlayData playData);

        public Task<int> CountUserGames(int userID);
        public Task<TimeSpan> CountUserTotalPlaytime(int userID);
    }
}
