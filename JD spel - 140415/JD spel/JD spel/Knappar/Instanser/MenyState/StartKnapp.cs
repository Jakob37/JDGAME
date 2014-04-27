using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class StartKnapp : Clickable
    {
        Game1 game;

        public StartKnapp(Game1 game, Sprite spriteSheet, Vector2 position)
            : base(spriteSheet, position)
        {
            displaySprite = spriteSheet.GetSubSprite(new Rectangle(0, 50, 80, 40));
            this.game = game;
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
            game.runningState = game.levelMenyState;
        }

    }
}
