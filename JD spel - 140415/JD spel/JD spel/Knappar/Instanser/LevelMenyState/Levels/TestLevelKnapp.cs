using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class TestLevelKnapp : LevelKnapp
    {
        public TestLevelKnapp(Game1 game, Sprite spriteSheet, Vector2 position, Level level)
            : base(game, spriteSheet, position, level)
        {
            displaySprite = spriteSheet.GetSubSprite(new Rectangle(80, 200, 50, 30));
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
            IncreaseStartCount();

            game.levelState.Initialize();
            //game.levelState.SetLevel(1);
            level.Initialize(game.levelState);
            game.levelState.MakeLevel(Level);

            game.runningState = game.levelState;
        }
    }
}

