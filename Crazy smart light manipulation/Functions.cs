using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NanoleafSpace
{
    public partial class Nanoleaf
    {
        public void TogglePower()
        {
            string url = $"http://{IpAddress}:{Port}/api/v1/{AuthToken}/state/on";


        }
    }
}
