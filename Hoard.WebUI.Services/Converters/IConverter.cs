﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hoard.WebUI.Services.Converters
{
    public interface IConverter
    {
        public Task<string> ConvertGameData();
    }
}
