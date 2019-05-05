using DrawingProgram;
using System.Collections.Generic;

namespace DrawingProgram.Command
{
    public interface IDrawingCommand
    {
        void CommandValidation(List<string> cmd);

        DrawingCanvas ExecuteCommand();
    }
}
