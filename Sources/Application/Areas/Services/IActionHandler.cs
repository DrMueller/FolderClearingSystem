using System;

namespace Mmu.Fcs.Console.Areas.Services
{
    public interface IActionHandler
    {
        void HandleAction(Action action);
    }
}