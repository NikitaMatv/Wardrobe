using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wardrobe.Component
{
    public partial class Type
    {
        public string AVGTemp
        {
            get { return $"от {TemperatureMin}° до {TemperatureMax}°"; }
        }
    }
}
