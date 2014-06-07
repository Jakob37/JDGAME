using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class FiendeSkott : Skott
    {
        

        public FiendeSkott(Game1 game, Sprite spriteSheet, State presentState)
            : base(game, spriteSheet, presentState)
        {
            lever = true;
        }

        public override void Uppdatera(GameTime gameTime)
        {
            base.Uppdatera(gameTime);

            if (liv <= 0)
            {
                lever = false;
            }
        }
    }
}
