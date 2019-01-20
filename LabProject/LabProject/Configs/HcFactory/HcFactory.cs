using System.Collections.Generic;
using System.IO;
using System.Linq;
using LabProject.Hashing;

namespace LabProject.Configs.HcFactory
{
    public static class HcFactory
    {
        public static ConfigModel BuildHardcodedModel()
        {
            const string testsDirectory = @"../../TestApps/tests";
            var cm = new ConfigModel {Programs = new List<ProgramModel>()};
            var pm1 = new ProgramModel
            {
                ExecutablePath = "dotnet",
                Arguments = @"../../TestApps/build/SumApp.dll",
                WorkingDirectory = testsDirectory,
                Tests = new List<TestModel>()
            };


            cm.Programs.Add(pm1);

            var pm2 = new ProgramModel
            {
                ExecutablePath = "dotnet",
                Arguments = @"../../TestApps/build/SortApp.dll",
                WorkingDirectory = testsDirectory,
                Tests = new List<TestModel>()
            };

            cm.Programs.Add(pm2);
//            int c = 0;
            foreach (var file in Directory.GetFiles(testsDirectory).Where(file => file.Contains("test-")))
            {
//                c++;
//                if (c > 10) break;
                pm1.Tests.Add(new TestModel(file, file.Replace("test-", "sum-").Replace(".in", ".out")));
                pm2.Tests.Add(new TestModel(file, file.Replace("test-", "sort-").Replace(".in", ".out")));
            }

            return cm;
        }

        public static void ComputeOutputHashes(ConfigModel configModel)
        {
            foreach (var program in configModel.Programs)
            {
                foreach (var test in program.Tests)
                {
                    var outputFile = Path.Combine(program.WorkingDirectory, test.ExpectedOutputFile);
                    var content = new StreamReader(new FileStream(outputFile, FileMode.Open)).ReadToEnd().Trim();
                    var hash = HashHelper.ComputeHash(content);
                    test.ExpectedOutputSignature = hash;
                }
            }
        }
    }
}