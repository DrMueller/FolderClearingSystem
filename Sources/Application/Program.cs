using Mmu.Fcs.Console.Areas.Services;
using Mmu.Mlh.ConsoleExtensions.Areas.Commands.Services;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Models;
using Mmu.Mlh.ServiceProvisioning.Areas.Initialization.Services;

namespace Mmu.Fcs.Console
{
    internal class Program
    {
        private static void Main()
        {
            var containerConfig = ContainerConfiguration.CreateFromAssembly(typeof(Program).Assembly, logInitialization: true);
            var container = ContainerInitializationService.CreateInitializedContainer(containerConfig);

            container.GetInstance<IPathInitializer>().InitializePath();
            container.GetInstance<IConsoleCommandsStartupService>().Start();
        }
    }
}