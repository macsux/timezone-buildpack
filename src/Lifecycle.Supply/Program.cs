﻿using System.Linq;

namespace Lifecycle.Supply
{
    class Program
    {
        static int Main(string[] args)
        {
            var argsWithCommand = new[] {"Supply"}.Concat(args).ToArray();
            return TimezoneBuildpack.Program.Main(argsWithCommand);
        }
    }
}