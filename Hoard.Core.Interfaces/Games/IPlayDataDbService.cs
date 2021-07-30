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

        public Task<int> CountUserOwnedGamesAsync(int hoarderID);
        public Task<int> CountUserDroppedGamesAsync(int hoarderID);
        public Task<TimeSpan> CountUserTotalPlaytimeAsync(int hoarderID);

        public Task<int> CountUserFinishedGamesByPlatformAsync(int hoarderID, int platformID);
        public Task<int> CountUserPlayedGamesByPlatformAsync(int hoarderID, int platformID);
        public Task<int> CountUserUnplayedGamesByPlatformAsync(int hoarderID, int platformID);
        public Task<int> CountUserDroppedGamesByPlatformAsync(int hoarderID, int platformID);
    }
}
