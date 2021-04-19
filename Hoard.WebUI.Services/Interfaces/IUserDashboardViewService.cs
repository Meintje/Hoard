using Hoard.WebUI.Services.ViewModels.UserDashboard;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.Interfaces
{
    public interface IUserDashboardViewService
    {
        public Task<UserDashboardViewModel> GetUserDashboard(int playerID);
    }
}
