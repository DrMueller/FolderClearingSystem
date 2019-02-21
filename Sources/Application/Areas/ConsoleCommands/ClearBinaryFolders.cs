using System;
using System.IO.Abstractions;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Fcs.Console.Areas.Services;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Mmu.Mlh.ConsoleExtensions.Areas.ConsoleOutput.Services;

namespace Mmu.Fcs.Console.Areas.ConsoleCommands
{
    public class ClearBinaryFolders : IConsoleCommand
    {
        private readonly IConsoleWriter _consoleWriter;
        private readonly IFileSystem _fileSystem;
        public string Description { get; } = "Clear binary folders (obj, bin)";
        public ConsoleKey Key { get; } = ConsoleKey.D2;

        public ClearBinaryFolders(
            IFileSystem fileSystem,
            IConsoleWriter consoleWriter)
        {
            _fileSystem = fileSystem;
            _consoleWriter = consoleWriter;
        }

        public Task ExecuteAsync()
        {
            var baseDirectoryInfo = _fileSystem.DirectoryInfo.FromDirectoryName(PathSingleton.Instance);
            Clear(baseDirectoryInfo);

            return Task.CompletedTask;
        }

        private void Clear(DirectoryInfoBase directoryInfo)
        {
            foreach (var subDirectory in directoryInfo.GetDirectories())
            {
                var upperDirectoryName = subDirectory.Name.ToUpperInvariant();

                // Skip Package folders
                if (Constants.PackageFolders.Contains(upperDirectoryName))
                {
                    continue;
                }

                if (Constants.BinaryFolders.Contains(upperDirectoryName))
                {
                    _consoleWriter.WriteLine("Deleting: " + subDirectory.Name, null, ConsoleColor.Yellow);
                    subDirectory.GetFiles().ToList().ForEach(f => f.Delete());
                    subDirectory.Delete(true);
                    continue;
                }

                Clear(subDirectory);
            }
        }
    }
}