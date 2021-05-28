using Hoard.Core.Entities.Base;
using Hoard.Core.Entities.Games.JoinEntities;
using System;
using System.Collections.Generic;

namespace Hoard.Core.Entities.Games
{
    public class Game : BaseEntityWithID
    {
        public string Title { get; set; }
        public string AlternateTitle { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Description { get; set; }

        public int PlatformID { get; set; }
        public virtual Platform Platform { get; set; }

        public int MediaTypeID { get; set; }
        public virtual MediaType MediaType { get; set; }

        public int LanguageID { get; set; }
        public virtual Language Language { get; set; }

        public string FullGenres 
        {
            get
            {
                string fullGenres = "";

                if (Genres != null && Genres.Count > 0)
                {
                    foreach (var gg in Genres)
                    {
                        fullGenres += $"{gg.Genre.Name}, ";
                    }
                    fullGenres = fullGenres.Substring(0, fullGenres.Length - 2);
                }

                return fullGenres;
            }
        }

        public string FullSeries
        {
            get
            {
                string fullSeries = "";

                if (Series != null && Series.Count > 0)
                {
                    foreach (var s in Series)
                    {
                        fullSeries += $"{s.Series.Name}, ";
                    }
                    fullSeries = fullSeries.Substring(0, fullSeries.Length - 2);
                }

                return fullSeries;
            }
        }

        public string FullModes
        {
            get
            {
                string fullModes = "";

                if (Modes != null && Modes.Count > 0)
                {
                    foreach (var m in Modes)
                    {
                        fullModes += $"{m.Mode.Name}, ";
                    }
                    fullModes = fullModes.Substring(0, fullModes.Length - 2);
                }

                return fullModes;
            }
        }

        public string FullDevelopers
        {
            get
            {
                string fullDevelopers = "";

                if (Developers != null && Developers.Count > 0)
                {
                    foreach (var d in Developers)
                    {
                        fullDevelopers += $"{d.Developer.Name}, ";
                    }
                    fullDevelopers = fullDevelopers.Substring(0, fullDevelopers.Length - 2);
                }

                return fullDevelopers;
            }
        }

        public string FullPublishers
        {
            get
            {
                string fullPublishers = "";

                if (Publishers != null && Publishers.Count > 0)
                {
                    foreach (var p in Publishers)
                    {
                        fullPublishers += $"{p.Publisher.Name}, ";
                    }
                    fullPublishers = fullPublishers.Substring(0, fullPublishers.Length - 2);
                }

                return fullPublishers;
            }
        }

        public virtual ICollection<GameGenre> Genres { get; set; }
        public virtual ICollection<GameMode> Modes { get; set; }
        public virtual ICollection<GameSeries> Series { get; set; }
        public virtual ICollection<GameDeveloper> Developers { get; set; }
        public virtual ICollection<GamePublisher> Publishers { get; set; }

        public virtual ICollection<PlayData> PlayData { get; set; }
    }
}
