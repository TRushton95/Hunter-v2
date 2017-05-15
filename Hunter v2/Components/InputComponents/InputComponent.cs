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

        public InputComponent()
        {
            keyW = new MoveUpCommand();
            keyA = new MoveLeftCommand();
            keyS = new MoveDownCommand();
            keyD = new MoveRightCommand();
            mouseLeft = new FireCommand();
            nullCommand = new NullCommand();
        }

        public Command processInput()
        {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            //needs velocity instead, position is limited to one direction at a time (see movement commands)
            if (currentKeyboardState.IsKeyDown(Keys.W)) {
                return keyW;
            }
            if (currentKeyboardState.IsKeyDown(Keys.A)) {
                return keyA;
            }
            if (currentKeyboardState.IsKeyDown(Keys.S)) {
                return keyS;
            }
            if (currentKeyboardState.IsKeyDown(Keys.D)) {
                return keyD;
            }

            previousMouseState = currentMouseState;
            currentMouseState = Mouse.GetState();

            if ((currentMouseState.LeftButton == ButtonState.Pressed) && !(previousMouseState.LeftButton == ButtonState.Pressed))
            {
                return mouseLeft;
            }

            return nullCommand;
        }
    }
}
