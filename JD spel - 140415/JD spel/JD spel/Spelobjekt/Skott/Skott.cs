using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class Skott : SpelObjekt
    {
        protected float range = 1000;

        public Skott(Game1 game, Sprite spriteSheet, State presentState)
            : base(game, spriteSheet, presentState)
        {
            lever = true;
        }

        public void SkjutSkott(Vector2 skottPosition_, Vector2 riktning_)
        {
            Center = skottPosition_;
            riktning = riktning_;
            lever = true;
        }

        public override void Uppdatera(GameTime gameTime)
        {
            base.Uppdatera(gameTime);
            IsOutside();
            UpdateRange();
        }

        private void IsOutside()
        {
            if (Position.X < -100 || Position.X > game.Window.ClientBounds.Width + 100
                || Position.Y < -100 || Position.Y > game.Window.ClientBounds.Height + 100)
            {
                lever = false;
            }
        }

        private void UpdateRange()
        {
            range -= hastighet;
            if (range <= 0)
                lever = false;
        }
    }
}
