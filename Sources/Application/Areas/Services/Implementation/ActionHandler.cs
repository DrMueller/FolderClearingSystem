using System;
using Mmu.Mlh.ConsoleExtensions.Areas.ExceptionHandling.Services;

namespace Mmu.Fcs.Console.Areas.Services.Implementation
{
    public class ActionHandler : IActionHandler
    {
        private readonly IExceptionHandler _exceptionHandler;

        public ActionHandler(IExceptionHandler exceptionHandler)
        {
            _exceptionHandler = exceptionHandler;
        }

        public void HandleAction(Action action)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                _exceptionHandler.HandleException(ex);
            }
        }
    }
}