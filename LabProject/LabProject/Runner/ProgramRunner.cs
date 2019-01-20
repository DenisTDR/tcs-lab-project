using LabProject.Configs;

namespace LabProject.Runner
{
    public class ProgramRunner
    {
        public static void Run(ProgramModel program, bool? showOnly)
        {
            foreach (var test in program.Tests)
            {
                TestRunner.Run(program, test, showOnly);
            }
        }
    }
}