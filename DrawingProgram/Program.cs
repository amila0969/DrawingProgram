using DrawingProgram.Command;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DrawingProgram
{
    public class Program
    {
        static void Main(string[] args)
        {
            DrawingCanvas drawingCanvas = null;
            List<string> input = new List<string>();
            ShowDescription();
            while (true)
            {
                try
                {
                    Console.WriteLine("Please Enter Commad Here :");
                    input = Console.ReadLine().Split(' ').Where(x => !string.IsNullOrEmpty(x)).ToList();;
                    var command = DrawingCommandFactory.CreateCommandInstance(input, drawingCanvas);
                    var param = input.Skip(1).ToList();
                    command.CommandValidation(param);
                    drawingCanvas = command.ExecuteCommand();
                    Console.WriteLine(drawingCanvas.ToString());
                }
                catch (ArgumentNullException ex)
                {
                    Console.WriteLine(ex.ParamName);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }
        }

        private static void ShowDescription()
        {
            Console.WriteLine("Please use following commands to execute this drawing program");
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("\t\t\tInstructions");
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("Description\t\t\t\t\t\tCommand\t\t\tExample");
            Console.WriteLine("Create a new canvas of width w and height h\t\tC w h\t\t\tC 10 5");
            Console.WriteLine("\n");
            Console.WriteLine("Create a new line from (x1,y1) to (x2,y2).\nCurrently only horizontal or vertical lines are\nsupported. Horizontal and vertical lines will be\tL x1 y1 x2 y2\t\tL 1 4 1 4\ndrawn using the 'x' character.");
            Console.WriteLine("\n");
            Console.WriteLine("Create a new rectangle, whose upper left\ncorner is (x1,y1) and lower right corner is (x2,y2).\nHorizontal and vertical lines will be drawn\t\tR x1 y1 x2 y2\nusing the 'x' character.");
            Console.WriteLine("\n");
            Console.WriteLine("Fill the entire area connected to (x,y) with\n'colour' c. The behaviour of this is the same as that\nof the 'bucket fill' tool in paint programs.\t\tB x y c");
            Console.WriteLine("\n");
            Console.WriteLine("Quit the progra\t\t\t\t\t\tQ");
            Console.WriteLine("-----------------------------------------------------------------------");
            Console.WriteLine("\n");
        }
    }
}
