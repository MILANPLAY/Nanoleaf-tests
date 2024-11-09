using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NanoleafSpace
{
    public partial class Nanoleaf
    {
        private readonly HttpClient client = new HttpClient();

        public string IpAddress { get; set;}
        public int Port = 16021;
        private string AuthToken;

        internal Nano_Types Nanotype = Nano_Types.Shapes;


        public Nanoleaf(string IpAddress, int Port = 16021)
        {
            this.IpAddress = IpAddress;
            this.Port = Port;
            Setup();
        }

        private async void Setup()
        {
            if (!Directory.Exists("Devices"))
            {
                Directory.CreateDirectory("Devices");
            }

            await GetAuthToken();

        }

    }
    
}
