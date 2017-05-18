using Hunter_v2.Commands;
using Hunter_v2.Components.Interfaces;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hunter_v2.Components.InputComponents
{
    class InputComponent : IInputComponent
    {
        public KeyboardState currentKeyboardState { get; set; }
        public KeyboardState previousKeyboardState { get; set; }

        public MouseState currentMouseState { get; set; }
        public MouseState previousMouseState { get; set; }

        public Command keyW { get; set; }
        public Command keyA { get; set; }
        public Command keyS { get; set; }
        public Command keyD { get; set; }
        public Command mouseLeft { get; set; }
        public Command nullCommand { get; set; }
        public List<Command> commands { get; set; }

        public InputComponent()
        {
            keyW = new MoveUpCommand();
            keyA = new MoveLeftCommand();
            keyS = new MoveDownCommand();
            keyD = new MoveRightCommand();
            mouseLeft = new FireCommand();
            nullCommand = new NullCommand();
        }

        public List<Command> processInput()
        {
            commands = new List<Command>();

            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            //needs velocity instead, position is limited to one direction at a time (see movement commands)
            if (currentKeyboardState.IsKeyDown(Keys.W)) {
                commands.Add(keyW);
            }
            if (currentKeyboardState.IsKeyDown(Keys.A)) {
                commands.Add(keyA);
            }
            if (currentKeyboardState.IsKeyDown(Keys.S)) {
                commands.Add(keyS);
            }
            if (currentKeyboardState.IsKeyDown(Keys.D)) {
                commands.Add(keyD);
            }

            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            if ((currentMouseState.LeftButton == ButtonState.Pressed) && !(previousMouseState.LeftButton == ButtonState.Pressed))
            {
                commands.Add(mouseLeft);
            }

            if (commands.Count() == 0)
            {
                commands.Add(nullCommand);
            }

            return commands;
        }
    }
}
