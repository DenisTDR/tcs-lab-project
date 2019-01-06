using System.IO;
using LabProject.Configs.HcFactory;
using Newtonsoft.Json;

namespace LabProject
{
    class Program
    {
        static void Main(string[] args)
        {
//            WriteHcConfig();
        }

        static void WriteHcConfig()
        {
            var cm = HcFactory.BuildHardcodedModel();
            HcFactory.ComputeOutputHashes(cm);
            using (var sw = new StreamWriter(new FileStream("config.json", FileMode.OpenOrCreate)))
            {
                sw.WriteLine(JsonConvert.SerializeObject(cm));
            }
        }
    }
}