using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class Level2Knapp : Clickable
    {
        Game1 game;

        public Level2Knapp(Game1 game, Sprite spriteSheet, Vector2 position)
            : base(spriteSheet, position)
        {
            displaySprite = spriteSheet.GetSubSprite(new Rectangle(80, 80, 50, 30));
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
            game.levelState.SetLevel(2);
            game.runningState = game.levelState;
        }
    }
}
