using LabProject.Configs;

namespace LabProject.Runner
{
    public class ConfigRunner
    {
        public static void Run(ConfigModel config, bool? showOnly = null)
        {
            foreach (var program in config.Programs)
            {
                ProgramRunner.Run(program, showOnly);
            }
        }
    }
}