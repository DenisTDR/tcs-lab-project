using System;
using System.Collections.Generic;
using System.IO;
using LabProject.Configs;
using LabProject.Configs.HcFactory;
using LabProject.Hashing;
using LabProject.Runner;
using Newtonsoft.Json;

namespace LabProject
{
    class Program
    {
        static void Main(string[] args)
        {
//            WriteHcConfig();
            ConfigModel config = ConfigReader.Read();
            ConfigRunner.Run(config, true);
        }

        static void WriteHcConfig()
        {
            var cm = HcFactory.BuildHardcodedModel();
            HcFactory.ComputeOutputHashes(cm);
            using (var sw = new StreamWriter(new FileStream("config.json", FileMode.Create)))
            {
                sw.WriteLine(JsonConvert.SerializeObject(cm, Formatting.Indented));
            }
        }
    }
}