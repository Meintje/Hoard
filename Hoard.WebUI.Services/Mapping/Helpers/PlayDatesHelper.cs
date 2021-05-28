using Hoard.Core.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.Mapping.Helpers
{
    internal static class PlayDatesHelper
    {
        internal static string GetPlayDatesString(DateTime? startDate, DateTime? endDate)
        {
            string playDates = "dates unknown";

            if (startDate != null)
            {
                playDates = $"from {((DateTime)startDate).ToString(EntityConstants.DateFormatString)}";
            }

            if (startDate != null && endDate != null)
            {
                playDates += $" till {((DateTime)endDate).ToString(EntityConstants.DateFormatString)}";
            }
            else if (endDate != null)
            {
                playDates = $"till {((DateTime)endDate).ToString(EntityConstants.DateFormatString)}";
            }

            return playDates;
        }
    }
}
