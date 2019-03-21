using System;
using LabProject.Configs;

namespace LabProject.Runner
{
    public class ProgramRunner
    {
        public static void Run(ProgramModel program, bool? showOnly)
        {
            var mistakes = 0;

            foreach (var test in program.Tests)
            {
                if (!TestRunner.Run(program, test, showOnly))
                {
                    ++mistakes;
                }
            }
            
            Console.WriteLine(mistakes + "/" + program.Tests.Count + " failed tests");
        }
    }
}