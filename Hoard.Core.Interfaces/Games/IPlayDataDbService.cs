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

        public Task<int> CountUserOwnedGames(int hoarderID);
        public Task<int> CountUserDroppedGames(int hoarderID);
        public Task<TimeSpan> CountUserTotalPlaytime(int hoarderID);

        public Task<int> CountUserFinishedGamesByPlatform(int hoarderID, int platformID);
        public Task<int> CountUserPlayedGamesByPlatform(int hoarderID, int platformID);
        public Task<int> CountUserUnplayedGamesByPlatform(int hoarderID, int platformID);
        public Task<int> CountUserDroppedGamesByPlatform(int hoarderID, int platformID);
    }
}
