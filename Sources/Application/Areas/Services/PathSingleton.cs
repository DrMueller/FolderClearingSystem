using System;
using System.Collections.Generic;
using System.Text;

namespace Mmu.Fcs.Console.Areas.Services
{
    public static class PathSingleton
    {
        public static string Instance { get; private set; }

        public static void Initialize(string instance)
        {
            Instance = instance;
        }
    }
}
