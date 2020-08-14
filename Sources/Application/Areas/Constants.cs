using System.Collections.Generic;

namespace Mmu.Fcs.Console.Areas
{
    public static class Constants
    {
        public static IReadOnlyCollection<string> BinaryFolders => new List<string>
        {
            "BIN",
            "OBJ"
        };

        public static IReadOnlyCollection<string> PackageFolders => new List<string>
        {
            "NODE_MODULES",
            "PACKAGES"
        };

        public static IReadOnlyCollection<string> LibraryFolders => new List<string>
        {
            "LIBRARIES"
        };
    }
}