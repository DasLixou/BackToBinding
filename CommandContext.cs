using CommandLine;

namespace BackToBinding
{
    internal sealed class CommandContext
    {
        [Option('i', "input", Required = true, HelpText = "Input header filename")]
        public string InputFilename { get; set; }

        [Option('o', "output", Required = true, HelpText = "Output directory")]
        public string OutputDirectory { get; set; }

        [Option('m', "mainName", Required = true, HelpText = "Main Name")]
        public string MainName { get; set; }
    }
}
