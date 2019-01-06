using System.Collections.Generic;

namespace LabProject.Configs.HcFactory
{
    public class HcFactory
    {
        public static ConfigModel BuildHardcodedModel()
        {
            var cm = new ConfigModel {Programs = new List<ProgramModel>()};
            var pm1 = new ProgramModel
            {
                ExecutablePath = @"C:\Program Files\dotnet\dotnet.exe",
                Arguments = "run",
                WorkingDirectory = @"D:\Projects\UPT\master\tcs\lab\TestApps\SumApp",
                Tests = new List<TestModel>
                {
                    new TestModel
                    {
                        Input = "23 23 23 24324 234 234 2342 3423 423 32 42343333 32234 234",
                        ExpectedOutput = "42406882"
                    }
                }
            };
            cm.Programs.Add(pm1);

            var pm2 = new ProgramModel
            {
                ExecutablePath = @"C:\Program Files\dotnet\dotnet.exe",
                Arguments = "run",
                WorkingDirectory = @"D:\Projects\UPT\master\tcs\lab\TestApps\SortApp",
                Tests = new List<TestModel>
                {
                    new TestModel
                    {
                        Input = "23 69 23 24324 234 234 2342 3423 423 32 42343333 32234 234",
                        ExpectedOutput = "23 23 32 69 234 234 234 423 2342 3423 24324 32234 42343333"
                    }
                }
            };
            cm.Programs.Add(pm2);

            return cm;
        }
    }
}