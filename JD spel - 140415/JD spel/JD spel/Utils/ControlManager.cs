using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    public static class ControlManager
    {
        private static KeyboardState currentKeyboardState;
        private static KeyboardState previousKeyboardState;

        public static void Uppdatera(GameTime gameTime)
        {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
        }

        public static Boolean IsKeyPressed(Keys key)
        {
            if (currentKeyboardState.IsKeyUp(key) && previousKeyboardState.IsKeyDown(key))
            {
                return true;
            }
            return false;
        }
    }
}
