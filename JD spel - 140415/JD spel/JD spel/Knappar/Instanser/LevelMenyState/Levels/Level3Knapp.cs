using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class Level3Knapp : Clickable
    {
        Game1 game;

        public Level3Knapp(Game1 game, Sprite spriteSheet, Vector2 position)
            : base(spriteSheet, position)
        {
            displaySprite = spriteSheet.GetSubSprite(new Rectangle(80, 110, 50, 30));
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
            game.levelState.Initialize();
            game.levelState.SetLevel(3);
            game.runningState = game.levelState;
        }
    }
}
