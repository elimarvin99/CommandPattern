using System;
using System.Collections.Generic;

namespace CommandPattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter Commands (ON/OFF) : ");
            string cmd = Console.ReadLine().ToUpper();

            Light lamp = new Light();
            ICommand switchUp = new FlipUpCommand(lamp);
            ICommand switchDown = new FlipDownCommand(lamp);

            Switch s = new Switch();

            if (cmd == "ON")
            {
                s.StoreAndExecute(switchUp);
            }
            else if (cmd == "OFF")
            {
                s.StoreAndExecute(switchDown);
            }
            else
            {
                Console.WriteLine("Command \"ON\" or \"OFF\" is required.");
            }

            Console.ReadLine();
        }

        public interface ICommand
        {
            void Execute();
        }

        /// <summary>
        /// The 'Invoker' class
        /// </summary>
        public class Switch
        {
            private List<ICommand> _commands = new List<ICommand>();

            public void StoreAndExecute(ICommand command)
            {
                _commands.Add(command);
                command.Execute();
            }
        }

        /// <summary>
        /// The 'Receiver' class
        /// </summary>
        public class Light
        {
            public void TurnOn() => Console.WriteLine("The light is on");
            public void TurnOff() => Console.WriteLine("The light is off");
        }

        /// <summary>
        /// The command for turning on the light
        /// </summary>
        public class FlipUpCommand : ICommand
        {
            private Light _light;
            public FlipUpCommand(Light light)
            {
                _light = light;
            }

            public void Execute() => _light.TurnOn();
        }

        /// <summary>
        /// The command for turning off the light
        /// </summary>
        public class FlipDownCommand : ICommand
        {
            private Light _light;
            public FlipDownCommand(Light light)
            {
                _light = light;
            }

            public void Execute() => _light.TurnOff();
        }
    }
}
