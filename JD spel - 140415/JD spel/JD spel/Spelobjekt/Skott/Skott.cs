using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JD_spel
{
    class Skott : SpelObjekt
    {
        protected float range = 1000;

        public Skott(Game1 game, Sprite spriteSheet)
            : base(game, spriteSheet)
        {
            lever = true;
            drawLayer = 0.8f;
        }

        public void SkjutSkott(SpelObjekt shooter, Vector2 riktning_)
        {
            Position = shooter.Position;
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

        public override void Rita(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bild.Texture, Position, bild.SourceRectangle, Color.White * transparency, (float)(Radians), CenterOffset, 1.0f, SpriteEffects.None, drawLayer);
        }

    }
}
