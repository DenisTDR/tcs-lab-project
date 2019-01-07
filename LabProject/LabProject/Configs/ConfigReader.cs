using System.IO;
using Newtonsoft.Json;

namespace LabProject.Configs
{
    public class ConfigReader
    {
        public static ConfigModel Read()
        {
            using (var r = new StreamReader("config.json"))
            {
                var json = r.ReadToEnd();
                
                return JsonConvert.DeserializeObject<ConfigModel>(json);
            }
        }
    }
}