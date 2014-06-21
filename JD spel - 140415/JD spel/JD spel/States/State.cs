using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JD_spel
{
    public class State
    {
        protected Game1 game;
        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;

        public State(Game1 game)
        {
            this.game = game;

        }

        public virtual void Initialize()
        {
        }
        
        public virtual void Uppdatera(GameTime gameTime)
        {
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
        }

        public virtual void Rita(SpriteBatch spriteBatch)
        { }
    }
}
