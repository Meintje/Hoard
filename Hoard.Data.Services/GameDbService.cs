﻿using Hoard.Data.Persistence.DataAccess;
using Hoard.Core.Entities.Game;
using Hoard.Core.Interfaces;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;

namespace Hoard.Data.Services
{
    public class GameDbService : IGameDbService
    {
        private readonly HoardDbContext _context;

        public GameDbService(HoardDbContext context)
        {
            _context = context;
        }

        public async Task<ICollection<Game>> GetAllGames()
        {
            var items = await _context.Games
                .Include(g => g.Platform)
                .Include(g => g.Genres).ThenInclude(genre => genre.Genre)
                .ToListAsync();

            return items;
        }

        public async Task<Game> GetGameDetails(int id)
        {
            var item = await _context.Games
                .Include(g => g.PlayData).ThenInclude(pd => pd.Playthroughs).ThenInclude(pt => pt.PlayStatus)
                .Include(g => g.PlayData).ThenInclude(pd => pd.Player)
                .Include(g => g.Platform)
                .Include(g => g.Genres).ThenInclude(genre => genre.Genre)
                .Where(g => g.ID == id).FirstOrDefaultAsync();

            return item;
        }

        public async Task<Game> GetGameUpdateData(int id)
        {
            var item = await _context.Games
                .Include(g => g.Genres)
                .Where(g => g.ID == id).FirstOrDefaultAsync();

            return item;
        }

        public async Task<ICollection<Game>> GetGamesByTitle(string title)
        {
            var items = await _context.Games.Where(g => g.Title == title).ToListAsync();

            return items;
        }

        public async Task CreateGame(Game newGame)
        {
            _context.Add(newGame);

            await _context.SaveChangesAsync();
        }

        public async Task UpdateGame(Game updatedGame)
        {
            var oldGenres = _context.GameGenres.Where(gg => gg.GameID == updatedGame.ID).ToList();
            UpdateManyToManyRelation(oldGenres, updatedGame.Genres);

            _context.Update(updatedGame);

            await _context.SaveChangesAsync();
        }

        private void UpdateManyToManyRelation<T>(IEnumerable<T> oldItems, IEnumerable<T> newItems) where T : class
        {
            _context.RemoveRange(oldItems);
            _context.AddRange(newItems);
        }

        public async Task DeleteGame(int id)
        {
            var game = await _context.Games.Where(g => g.ID == id).FirstOrDefaultAsync();

            _context.Games.Remove(game);

            await _context.SaveChangesAsync();
        }

        public async Task<ICollection<Platform>> GetAllPlatforms()
        {
            var items = await _context.Platforms.ToListAsync();

            return items;
        }

        public async Task<ICollection<Genre>> GetAllGenres()
        {
            var items = await _context.Genres.ToListAsync();

            return items;
        }

        public async Task<Playthrough> GetPlaythroughDetails(int pdID, int ordinalNumber)
        {
            var item = await _context.Playthroughs
                .Include(pt => pt.PlayStatus)
                .Include(pt => pt.PlayData).ThenInclude(pd => pd.Player)
                .Include(pt => pt.PlayData).ThenInclude(pd => pd.Game)
                .Where(pt => pt.PlayDataID == pdID && pt.OrdinalNumber == ordinalNumber).FirstOrDefaultAsync();

            return item;
        }
    }
}
