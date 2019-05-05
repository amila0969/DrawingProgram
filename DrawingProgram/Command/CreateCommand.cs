using System;
using System.Collections.Generic;
using System.Linq;

namespace DrawingProgram.Command
{
    public class CreateCommand : IDrawingCommand
    {
        private int _width;
        private int _height;

        public void CommandValidation(List<string> cmd)
        {
            if (cmd == null || !cmd.Any())
                throw new ArgumentNullException("missing command arguments");

            if (cmd.Count != 2)
                throw new ArgumentException("only accept 2 arguments: width & height");

            if ((!int.TryParse(cmd[0], out _width) || _width <= 0) ||
                (!int.TryParse(cmd[1], out _height) || _height <= 0))
                throw new ArgumentException("arguments should be a positive int");
        }

        public DrawingCanvas ExecuteCommand()
        {
            var canvas = new DrawingCanvas(_width, _height);
            return canvas;
        }
    }
}
