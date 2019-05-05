using System;
using System.Collections.Generic;
using System.Linq;

namespace DrawingProgram.Command
{
    public class RectangleCommand : IDrawingCommand
    {
        private int _x1, _x2, _y1, _y2;
        private DrawingCanvas _drawingCanvas;

        public RectangleCommand(DrawingCanvas drawingCanvas)
        {
            _drawingCanvas = drawingCanvas ?? throw new ArgumentNullException("should create a canvas first");
        }

        public void CommandValidation(List<string> cmd)
        {
            if (cmd == null || !cmd.Any())
                throw new ArgumentNullException("missing command arguments");

            if (cmd.Count != 4)
                throw new ArgumentException("only accept 4 arguments: x1,x2,y1,y2");

            if ((!int.TryParse(cmd[0], out _x1) || _x1 <= 0) ||
                (!int.TryParse(cmd[2], out _x2) || _x2 <= 0) ||
                (!int.TryParse(cmd[1], out _y1) || _y1 <= 0) ||
                (!int.TryParse(cmd[3], out _y2) || _y2 <= 0))
                throw new ArgumentException("arguments should be a positive int");

            if ((_x1 > _x2) || (_y1 > _y2))
                throw new ArgumentException("arguments wrong: x1 > x2 or y1 > y2");

            if ((_x2 > _drawingCanvas._width - 2) || (_y2 > _drawingCanvas._height - 2))
                throw new ArgumentException("point should be in the canvas");
        }

        public DrawingCanvas ExecuteCommand()
        {
            for (int i = _y1; i <= _y2; i++)
            {
                for (int j = _x1; j <= _x2; j++)
                {
                    if (i == _y1 || i == _y2 || j == _x1 || j == _x2)
                        _drawingCanvas.cells[j, i] = _drawingCanvas.lineChar;
                    else
                        _drawingCanvas.cells[j, i] = ' ';
                }
            }
            return _drawingCanvas;
        }
    }
}
