using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.Mapping.Helpers
{
    public static class PlaytimeHelper
    {
        public static string GetLongPlaytimeString(TimeSpan timespan)
        {
            string playtime = "";
            int days = timespan.Days;
            int hours = timespan.Hours;
            int minutes = timespan.Minutes;

            if (days > 1)
            {
                playtime += $"{days} days, ";
            }
            else if (days == 1)
            {
                playtime += $"{days} day, ";
            }

            if (hours == 1)
            {
                playtime += $"{hours} hour, ";
            }
            else
            {
                playtime += $"{hours} hours, ";
            }

            if (minutes == 1)
            {
                playtime += $"{minutes} minute";
            }
            else
            {
                playtime += $"{minutes} minutes";
            }

            return playtime;
        }

        public static string GetShortPlaytimeString(TimeSpan timespan)
        {
            string playtime = "";

            if (timespan.Days > 0)
            {
                playtime += $"{timespan.Days}.";
            }

            playtime += timespan.ToString(@"hh\:mm");

            return playtime;
        }

        public static string GetPlaytimeStringInHours(TimeSpan timespan)
        {
            string playtime = "";
            int hours = (int)timespan.TotalHours;
            int minutes = timespan.Minutes;

            if (hours == 1)
            {
                playtime += $"{hours} hour, ";
            }
            else
            {
                playtime += $"{hours} hours, ";
            }

            if (minutes == 1)
            {
                playtime += $"{minutes} minute";
            }
            else
            {
                playtime += $"{minutes} minutes";
            }

            return playtime;
        }
    }
}
