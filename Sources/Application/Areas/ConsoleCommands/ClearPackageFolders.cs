using System;
using System.IO.Abstractions;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Fcs.Console.Areas.Services;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using Mmu.Mlh.ConsoleExtensions.Areas.ConsoleOutput.Services;

namespace Mmu.Fcs.Console.Areas.ConsoleCommands
{
    public class ClearPackageFolders : IConsoleCommand
    {
        private IActionHandler _actionHandler;
        private IConsoleWriter _consoleWriter;
        private IFileSystem _fileSystem;
        public string Description { get; } = "Clear package folders (node_modules, packages)";
        public ConsoleKey Key { get; } = ConsoleKey.D1;

        public ClearPackageFolders(
            IFileSystem fileSystem,
            IConsoleWriter consoleWriter,
            IActionHandler actionHandler)
        {
            _fileSystem = fileSystem;
            _consoleWriter = consoleWriter;
            _actionHandler = actionHandler;
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

                if (Constants.PackageFolders.Contains(upperDirectoryName))
                {
                    _consoleWriter.WriteLine("Deleting: " + subDirectory.Name, null, ConsoleColor.Yellow);
                    subDirectory.GetFiles().ToList().ForEach(
                        f =>
                        {
                            _actionHandler.HandleAction(f.Delete);
                        });

                    _actionHandler.HandleAction(() => subDirectory.Delete(true));
                    continue;
                }

                Clear(subDirectory);
            }
        }
    }
}