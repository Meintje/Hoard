using System;

namespace Hoard.WebUI.Services.ViewModels.UserDashboard.InnerModels
{
    public class UserDashboardEventViewModel
    {
        public DateTime Date { get; set; }
        public string DateString { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string URL { get; set; }
    }
}
