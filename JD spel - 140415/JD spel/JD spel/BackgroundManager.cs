using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace JD_spel
{
    public enum Background {
        none,
        grass,
        mud
    }

    class BackgroundManager
    {
        private Game1 game;

        private Background backgroundType;

        private Sprite grassTile;
        private Sprite mudTile;

        private BackgroundSprite backgroundSprite;

        public BackgroundManager(Game1 game)
        {
            this.game = game;

            grassTile = new Sprite(game.Content.Load<Texture2D>("Tiles/GrassTile"));
            mudTile = new Sprite(game.Content.Load<Texture2D>("Tiles/MudTile"));
        }

        public void ChangeBackground(Background backgroundType)
        {
            this.backgroundType = backgroundType;

            int height = game.Window.ClientBounds.Height;
            int width = game.Window.ClientBounds.Width;

            switch (backgroundType)
            {
                case Background.grass:
                    {
                        backgroundSprite = new BackgroundSprite(width, height, grassTile);
                        break;
                    }
                case Background.mud:
                    {
                        backgroundSprite = new BackgroundSprite(width, height, mudTile);
                        break;
                    }
                case Background.none:
                    {
                        break;
                    }
                default:
                    {
                        throw new ArgumentException("Unknown background!");
                    }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (backgroundType != null)
            {
                backgroundSprite.Draw(spriteBatch);
            }
        }
    }
}
