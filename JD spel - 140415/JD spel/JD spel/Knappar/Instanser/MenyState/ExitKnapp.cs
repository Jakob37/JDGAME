using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class ExitKnapp : Clickable
    {
        private Game1 game;

        public ExitKnapp(Game1 game, Sprite spriteSheet, Vector2 position)
            : base(spriteSheet, position)
        {
            this.game = game;
            displaySprite = spriteSheet.GetSubSprite(new Rectangle(0, 90, 80, 40));
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (IsLeftClicked())
            {
                ClickLogic();
            }
        }

        private void ClickLogic()
        {
            game.Exit();
        }
    }
}
