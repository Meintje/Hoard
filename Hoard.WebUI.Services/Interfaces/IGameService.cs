using Hoard.WebUI.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.Interfaces
{
    public interface IGameService
    {
        public GameIndexViewModel GetGameIndex();
    }
}
