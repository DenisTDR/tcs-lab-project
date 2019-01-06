using System.Collections.Generic;

namespace LabProject.Configs
{
    public class ProgramModel
    {
        public string ExecutablePath { get; set; }
        public string Arguments { get; set; }
        public string WorkingDirectory { get; set; }
        public List<TestModel> Tests { get; set; }
    }
}