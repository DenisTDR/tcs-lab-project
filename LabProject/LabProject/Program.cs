using System;
using System.IO;
using LabProject.Configs.HcFactory;
using LabProject.Hashing;
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