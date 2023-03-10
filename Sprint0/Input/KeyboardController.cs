using Microsoft.Xna.Framework.Input;
using Sprint0.Commands;
using Sprint0.Commands.Misc;
using System.Collections.Generic;

namespace Sprint0.Controllers
{
    public class KeyboardController : IController
    {
        // Can be utilized to handle more specific keyboard input
        private KeyboardState PrevState;

        // A list of every mapping of action maps to commands
        private readonly Dictionary<ActionMap, ICommand> CommandMappings;

        public KeyboardController(Dictionary<ActionMap, ICommand> commandMappings)
        {
            CommandMappings = commandMappings;
            PrevState = Keyboard.GetState();
        }

        public void Update()
        {
            KeyboardState currentState = Keyboard.GetState();

            foreach (var mapping in CommandMappings)
            {
                if (mapping.Key.IsActivated(PrevState, currentState))
                {
                    // Specific case for the command line - needs to know exactly what key was typed
                    if (mapping.Value is CommandLineTypeKeyCommand) (mapping.Value as CommandLineTypeKeyCommand).SetKeyTyped(mapping.Key.ActingKey);

                    mapping.Value.Execute();
                }
            }

            PrevState = currentState;
        }
    }
}
