using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using LabProject.Hashing;

namespace LabProject.Configs.HcFactory
{
    public static class HcFactory
    {
        public static ConfigModel BuildHardcodedModel()
        {
            var cm = new ConfigModel {Programs = new List<ProgramModel>()};
            var pm1 = new ProgramModel
            {
                ExecutablePath = @"C:\Program Files\dotnet\dotnet.exe",
                Arguments = @"D:\Projects\UPT\master\tcs\lab\TestApps\build\SumApp.dll",
                WorkingDirectory = @"D:\Projects\UPT\master\tcs\lab\TestApps\tests",
                Tests = new List<TestModel>()
            };
            for (var i = 1; i <= 25; i++)
            {
                var numberStr = string.Format(i.ToString("D3"), i);
                pm1.Tests.Add(new TestModel("input" + numberStr + ".in", "sum" + numberStr + ".out"));
            }

            cm.Programs.Add(pm1);

            var pm2 = new ProgramModel
            {
                ExecutablePath = @"C:\Program Files\dotnet\dotnet.exe",
                Arguments = @"D:\Projects\UPT\master\tcs\lab\TestApps\build\SortApp.dll",
                WorkingDirectory = @"D:\Projects\UPT\master\tcs\lab\TestApps\tests",
                Tests = new List<TestModel>()
            };
            for (var i = 1; i <= 25; i++)
            {
                var numberStr = string.Format(i.ToString("D3"), i);
                pm2.Tests.Add(new TestModel("input" + numberStr + ".in", "sort" + numberStr + ".out"));
            }

            cm.Programs.Add(pm2);

            return cm;
        }

        public static void ComputeOutputHashes(ConfigModel configModel)
        {
            foreach (var program in configModel.Programs)
            {
                foreach (var test in program.Tests)
                {
                    var outputFile = Path.Combine(program.WorkingDirectory, test.ExpectedOutputFile);
                    var content = new StreamReader(new FileStream(outputFile, FileMode.Open)).ReadToEnd();
                    var hash = HashHelper.ComputeHash(content);
                    test.ExpectedOutputSignature = hash;
                }
            }
        }
    }
}