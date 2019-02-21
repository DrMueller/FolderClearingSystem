using Mmu.Mlh.ConsoleExtensions.Areas.ConsoleOutput.Services;

namespace Mmu.Fcs.Console.Areas.Services.Implementation
{
    public class PathInitializer : IPathInitializer
    {
        private readonly IConsoleWriter _consoleWriter;

        public PathInitializer(IConsoleWriter consoleWriter)
        {
            _consoleWriter = consoleWriter;
        }

        public void InitializePath()
        {
            _consoleWriter.WriteLine("Please enter a path (Default is IFES)", null, null);
            var selectedPath = System.Console.ReadLine();

            if (string.IsNullOrEmpty(selectedPath))
            {
                selectedPath = "D:\\GIT\\IFES";
            }

            PathSingleton.Initialize(selectedPath);
        }
    }
}