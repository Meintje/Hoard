namespace Hoard.WebUI.Services.ViewModels.UserDashboard.InnerModels
{
    public class UserDashboardGameViewModel
    {
        public int PlayDataID { get; set; }
        public int OrdinalNumber { get; set; }
        public string PlaythroughNotes { get; set; }

        public int GameID { get; set; }
        public string GameTitle { get; set; }
        public string GamePlatform { get; set; }
    }
}
