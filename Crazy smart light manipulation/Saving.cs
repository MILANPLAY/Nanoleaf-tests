using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace NanoleafSpace
{
    public partial class Nanoleaf
    {
        private JObject ToJson()
        {
            var json = new JObject();
            json["IP"] = IpAddress;
            json["port"] = Port;
            json["authtoken"] = AuthToken;
            json["type"] = Nanotype.ToString();
            return json;
        }
        private void Save()
        {
            if (!Directory.Exists("Devices"))
            {
                Directory.CreateDirectory("Devices");
            }

             File.WriteAllText(Path.Join("Devices", $"{IpAddress}"),ToJson().ToString());
        }
        private void Load(JObject json)
        {
            Port = int.Parse(json["port"].ToString());
            AuthToken = json["authtoken"].ToString();
            Nanotype = (Nano_Types)Enum.Parse(typeof(Nano_Types), json["type"].ToString());
        }
    }
}