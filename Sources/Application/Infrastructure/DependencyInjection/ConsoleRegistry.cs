using System.IO.Abstractions;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Models;
using StructureMap;

namespace Mmu.Fcs.Console.Infrastructure.DependencyInjection
{
    public class ConsoleRegistry : Registry
    {
        public ConsoleRegistry()
        {
            Scan(
                scanner =>
                {
                    scanner.AssemblyContainingType<ConsoleRegistry>();
                    scanner.AddAllTypesOf<IConsoleCommand>();

                    scanner.WithDefaultConventions();
                });

            For<IFileSystem>().Use<FileSystem>().Singleton();
        }
    }
}