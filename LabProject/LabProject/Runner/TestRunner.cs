using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using LabProject.Configs;
using LabProject.Hashing;
using Newtonsoft.Json;

namespace LabProject.Runner
{
    public class TestRunner
    {
        public static void Run(ProgramModel program, TestModel test, bool? showOnly)
        {
            var startInfo = new ProcessStartInfo
            {
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                FileName = program.ExecutablePath,
                Arguments = program.Arguments
            };

            // redirects on your choice


            var process = new Process {StartInfo = startInfo};
            process.Start();

            using (var r = new StreamReader(test.InputFile))
            {
                var input = r.ReadToEnd();
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
            }

            var output = process.StandardOutput.ReadToEnd().Trim();

            var outputHash = HashHelper.ComputeHash(output);

            var result = outputHash == test.ExpectedOutputSignature;
            if (showOnly == null || showOnly == true && result || showOnly == false && !result)
            {
                Console.Write("running test {0} for {1}", Path.GetFileName(test.InputFile),
                    Path.GetFileName(program.Arguments.Split(" ", StringSplitOptions.RemoveEmptyEntries)
                        .FirstOrDefault()));
                Console.Write("  hash:" + outputHash);
                Console.WriteLine("   result: " + (outputHash == test.ExpectedOutputSignature));
//                Console.WriteLine(output);
//                Console.WriteLine("outputHash=" + outputHash + "   ExpectedOutputHash=" + test.ExpectedOutputSignature);
            }
        }
    }
}