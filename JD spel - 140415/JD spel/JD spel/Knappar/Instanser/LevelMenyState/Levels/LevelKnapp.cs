using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JD_spel
{
    public abstract class LevelKnapp : Clickable
    {
        protected Game1 game;

        private Color statusColor;

        protected Level level;
        public Level Level { get { return level; } }

        private int winCount;
        private int loseCount;
        private int startCount;

        public LevelKnapp(Game1 game, Sprite spriteSheet, Vector2 position, Level level)
            : base(spriteSheet, position)
        {
            this.game = game;
            this.level = level;

            winCount = 0;
            loseCount = 0;
            startCount = 0;
        }

        private void ClickLogic()
        {
            IncreaseStartCount();

            game.levelState.Initialize();
            level.Initialize(game.levelState);
            game.levelState.MakeLevel(Level);

            game.runningState = game.levelState;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (IsLeftClicked())
            {
                ClickLogic();
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (winCount == 0 && loseCount == 0)
                statusColor = Color.White;
            else if (winCount == 0 && loseCount > 0)
                statusColor = Color.Red;
            else
                statusColor = Color.Green;

            spriteBatch.Draw(displaySprite.Texture, position, displaySprite.SourceRectangle, statusColor);
        }

        public void IncreaseWinCount()
        {
            winCount++;
        }

        public void IncreaseLoseCount()
        {
            loseCount++;
        }

        public void IncreaseStartCount()
        {
            startCount++;
        }
    }
}
