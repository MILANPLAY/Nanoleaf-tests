using Newtonsoft.Json.Linq;
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
        }

        public async Task Setup()
        {
            if (File.Exists(Path.Join("Devices",IpAddress)))
            {
                Console.WriteLine("File exists. loading ...");
                string props = File.ReadAllText(Path.Join("Devices", IpAddress));
                Load(JObject.Parse(props));
            }
            else
            {
                Console.WriteLine("New Device");
                await GetAuthToken();
                Save();
            }
      
        }
        
        public override string ToString()
        {
            return $"Nanoleaf IP: {IpAddress}\nNanoleaf Port: {Port}\nAuthToken: {AuthToken}\n\nType: {Nanotype}";
        }


    }
    
}
