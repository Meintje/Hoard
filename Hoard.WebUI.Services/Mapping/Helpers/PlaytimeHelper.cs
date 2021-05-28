using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.Mapping.Helpers
{
    internal static class PlaytimeHelper
    {
        internal static string GetLongPlaytimeString(TimeSpan timespan)
        {
            string playtime = "";
            int days = timespan.Days;
            int hours = timespan.Hours;
            int minutes = timespan.Minutes;

            if (days == 0 && hours == 0 && minutes == 0)
            {
                return "n/a";
            }

            string daysString;
            if (days == 1)
            {
                daysString = $"{days} day, ";
            }
            else
            {
                daysString = $"{days} days, ";
            }

            string hoursString;
            if (hours == 1)
            {
                hoursString = $"{hours} hour, ";
            }
            else
            {
                hoursString = $"{hours} hours, ";
            }

            string minutesString;
            if (minutes == 1)
            {
                minutesString = $"{minutes} minute";
            }
            else
            {
                minutesString = $"{minutes} minutes";
            }

            if (days > 0)
            {
                playtime += daysString;
                playtime += hoursString;
            }
            else if (hours > 0)
            {
                playtime += hoursString;
            }
            playtime += minutesString;

            return playtime;
        }

        internal static string GetShortPlaytimeString(TimeSpan timespan)
        {
            string playtime = "";
            int days = timespan.Days;
            int hours = timespan.Hours;
            int minutes = timespan.Minutes;

            if (days == 0 && hours == 0 && minutes == 0)
            {
                return "n/a";
            }

            if (days > 0)
            {
                playtime += $"{days}d {hours}h ";
            }
            else if (hours > 0)
            {
                playtime += $"{hours}h ";
            }

            playtime += $"{minutes}m";

            return playtime;
        }

        internal static string GetPlaytimeStringInHours(TimeSpan timespan)
        {
            string playtime = "";
            int hours = (int)timespan.TotalHours;
            int minutes = timespan.Minutes;

            if (hours == 0 && minutes == 0)
            {
                return "n/a";
            }

            if (hours > 0)
            {
                if (hours == 1)
                {
                    playtime += $"{hours} hour, ";
                }
                else
                {
                    playtime += $"{hours} hours, ";
                }
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
