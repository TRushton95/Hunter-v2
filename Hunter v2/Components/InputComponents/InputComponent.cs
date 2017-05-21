using Hunter_v2.Commands;
using Hunter_v2.Components.InputComponents.Commands;
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

        public Command keyDownW { get; set; }
        public Command keyDownA { get; set; }
        public Command keyDownS { get; set; }
        public Command keyDownD { get; set; }
        public Command keyUpW { get; set; }
        public Command keyUpA { get; set; }
        public Command keyUpS { get; set; }
        public Command keyUpD { get; set; }
        public Command mouseLeft { get; set; }
        public Command nullCommand { get; set; }
        public List<Command> commands { get; set; }

        public InputComponent()
        {
            keyDownW = new MoveUpCommand();
            keyDownA = new MoveLeftCommand();
            keyDownS = new MoveDownCommand();
            keyDownD = new MoveRightCommand();
            keyUpW = new StopVerticalCommand();
            keyUpA = new StopHorizontalCommand();
            keyUpS = new StopVerticalCommand();
            keyUpD = new StopHorizontalCommand();
            mouseLeft = new FireCommand();
            nullCommand = new NullCommand();
        }

        public List<Command> processInput()
        {
            commands = new List<Command>();

            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            //if any keys have been pressed
            if (currentKeyboardState.IsKeyDown(Keys.W)) {
                commands.Add(keyDownW);
            }
            if (currentKeyboardState.IsKeyDown(Keys.A)) {
                commands.Add(keyDownA);
            }
            if (currentKeyboardState.IsKeyDown(Keys.S)) {
                commands.Add(keyDownS);
            }
            if (currentKeyboardState.IsKeyDown(Keys.D)) {
                commands.Add(keyDownD);
            }

            //if any keys have been released
            if (currentKeyboardState.IsKeyUp(Keys.W) && previousKeyboardState.IsKeyDown(Keys.W))
            {
                commands.Add(keyUpW);
            }
            if (currentKeyboardState.IsKeyUp(Keys.A) && previousKeyboardState.IsKeyDown(Keys.A))
            {
                commands.Add(keyUpA);
            }
            if (currentKeyboardState.IsKeyUp(Keys.S) && previousKeyboardState.IsKeyDown(Keys.S))
            {
                commands.Add(keyUpS);
            }
            if (currentKeyboardState.IsKeyUp(Keys.D) && previousKeyboardState.IsKeyDown(Keys.D))
            {
                commands.Add(keyUpD);
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
