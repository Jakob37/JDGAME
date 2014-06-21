using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class LavaPool : FiendeSkott
    {
        private int livTimer;
        public LavaPool(Game1 game, Sprite spriteSheet, RunningState presentState)
            : base(game, spriteSheet, presentState)
        {
            this.game = game;
            this.spriteSheet = spriteSheet;

            bild = spriteSheet.GetSubSprite(new Rectangle(344, 3, 38, 35));
            Position = new Vector2(-100, -100);
            hastighet = 0;
            liv = 1000;
            skada = 1;
        }
        public override void Uppdatera(GameTime gameTime)
        {
            base.Uppdatera(gameTime);
            Death(gameTime);
        }
        private void Death(GameTime gameTime)
        {
            livTimer += gameTime.ElapsedGameTime.Milliseconds;
            if (livTimer >= 3000)
            {
                liv = 0;
            }
        }

    }
}
