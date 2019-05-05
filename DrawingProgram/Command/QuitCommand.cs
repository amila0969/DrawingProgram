using System;
using System.Collections.Generic;
using System.Linq;

namespace DrawingProgram.Command
{
    public class QuitCommand : IDrawingCommand
    {
        public void CommandValidation(List<string> cmd)
        {
            if (cmd == null)
                throw new ArgumentNullException("missing command arguments");

            if (cmd.Any())
                throw new ArgumentException("should have no arguments");
        }

        public DrawingCanvas ExecuteCommand()
        {
            Environment.Exit(Environment.ExitCode);
            return null;
        }
    }
}
