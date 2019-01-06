using System;
using LabProject.Configs.HcFactory;
using LabProject.Hashing;
using Newtonsoft.Json;

namespace LabProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
//            var cm = HcFactory.BuildHardcodedModel();
//            Console.WriteLine(JsonConvert.SerializeObject(cm));
            Console.Write(HashHelper.ComputeHash("tdr"));
        }
    }
}