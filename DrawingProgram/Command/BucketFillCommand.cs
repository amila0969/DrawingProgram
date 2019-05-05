using System;
using System.Collections.Generic;
using System.Linq;

namespace DrawingProgram.Command
{
    public class BucketFillCommand : IDrawingCommand
    {
        private int _x, _y;
        private char _colour;
        private DrawingCanvas _drawingCanvas;

        public BucketFillCommand(DrawingCanvas drawingCanvas)
        {
            _drawingCanvas = drawingCanvas ?? throw new ArgumentNullException("should create a canvas first");
        }

        public void CommandValidation(List<string> cmd)
        {
            if (cmd == null || !cmd.Any())
                throw new ArgumentNullException("missing command arguments");

            if (cmd.Count != 3)
                throw new ArgumentException("only accept 3 arguments: x,y,c");

            if ((!int.TryParse(cmd[0], out _x) || _x <= 0) ||
                (!int.TryParse(cmd[1], out _y) || _y <= 0))
                throw new ArgumentException("arguments should be a positive int");

            if ((_x > _drawingCanvas._width - 2) || (_y > _drawingCanvas._height - 2))
                throw new ArgumentException("point should be in the canvas");

            if (!char.TryParse(cmd[2], out _colour))
                throw new ArgumentException("colour should be a char");
        }

        public DrawingCanvas ExecuteCommand()
        {
            var queue = new Queue<Point>();
            queue.Enqueue(new Point(_x, _y));
            var traversed = new HashSet<Point>();

            while (queue.Any())
            {
                var current = queue.Dequeue();
                if (!traversed.Add(current) ||
                    _drawingCanvas.cells[current.X, current.Y] == _drawingCanvas.lineChar ||
                    _drawingCanvas.cells[current.X, current.Y] == _drawingCanvas.horizontalChar ||
                    _drawingCanvas.cells[current.X, current.Y] == _drawingCanvas.verticalChar)
                {
                    continue;
                }

                _drawingCanvas.cells[current.X, current.Y] = _colour;
                queue.Enqueue(new Point(current.X - 1, current.Y));
                queue.Enqueue(new Point(current.X + 1, current.Y));
                queue.Enqueue(new Point(current.X, current.Y - 1));
                queue.Enqueue(new Point(current.X, current.Y + 1));
            }

            return _drawingCanvas;
        }
    }
}
