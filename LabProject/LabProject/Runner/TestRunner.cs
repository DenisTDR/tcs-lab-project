using System;
using System.Diagnostics;
using System.IO;
using LabProject.Configs;
using LabProject.Hashing;
using Newtonsoft.Json;

namespace LabProject.Runner
{
    public class TestRunner
    {
        private static int count = 0;

        public static void Run(ProgramModel program, TestModel test)
        {
            Console.WriteLine("running test {0} for {1}", count++, program.Arguments);

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = false;

            // redirects on your choice
            startInfo.RedirectStandardInput = true;
            startInfo.RedirectStandardOutput = true;

            startInfo.FileName = program.ExecutablePath;
            startInfo.Arguments = program.Arguments;

            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();

            using (var r = new StreamReader(test.InputFile))
            {
                var input = r.ReadToEnd();
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
            }
            
            string output = process.StandardOutput.ReadToEnd();

            var outputHash = HashHelper.ComputeHash(output);
            
            Console.WriteLine(outputHash);
            Console.WriteLine(outputHash == test.ExpectedOutputSignature);
        }
    }
}