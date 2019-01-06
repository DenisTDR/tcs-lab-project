namespace LabProject.Configs
{
    public class TestModel
    {
        public TestModel()
        {
        }

        public TestModel(string inputFile, string expectedOutputFile, string expectedOutputSignature)
            : this(inputFile, expectedOutputFile)
        {
            ExpectedOutputSignature = expectedOutputSignature;
        }

        public TestModel(string inputFile, string expectedOutputFile)
        {
            InputFile = inputFile;
            ExpectedOutputFile = expectedOutputFile;
        }

        public string InputFile { get; set; }

        public string ExpectedOutputFile { get; set; }
        public string ExpectedOutputSignature { get; set; }
    }
}