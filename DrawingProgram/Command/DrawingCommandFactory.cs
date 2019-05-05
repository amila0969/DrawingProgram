using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingProgram.Command
{
    public class DrawingCommandFactory
    {
        public static IDrawingCommand CreateCommandInstance(List<string> cmd, DrawingCanvas drawingCanvas)
        {
            if (cmd == null || !cmd.Any())
                throw new ArgumentNullException("wrong command");

            switch (cmd[0])
            {
                case "C":
                    return new CreateCommand();
                case "L":
                    return new LineCommand(drawingCanvas);
                case "R":
                    return new RectangleCommand(drawingCanvas);
                case "B":
                    return new BucketFillCommand(drawingCanvas);
                case "Q":
                    return new QuitCommand();
                default:
                    throw new ArgumentException($"Not supported command: {cmd[0]}");
            }
        }
    }
}
