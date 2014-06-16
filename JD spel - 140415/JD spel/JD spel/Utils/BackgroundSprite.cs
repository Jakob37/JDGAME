using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class BackgroundSprite
    {

        private int windowWidth;
        private int windowHeight;
        private Sprite tile;

        public BackgroundSprite(int windowWidth, int windowHeight, Sprite tile)
        {
            this.windowWidth = windowWidth;
            this.windowHeight = windowHeight;
            this.tile = tile;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            List<Vector2> coordinates = GetCoordinates();

            foreach (Vector2 coordinate in coordinates)
            {
                spriteBatch.Draw(tile.Texture, coordinate, tile.SourceRectangle, Color.White, 0.0f, Vector2.Zero, 1f, SpriteEffects.None, 0f);
                //spriteBatch.Draw(tile.Texture, coordinate, tile.SourceRectangle, Color.White);
            }
        }

        private List<Vector2> GetCoordinates()
        {
            List<Vector2> coordinates = new List<Vector2>();

            int deltaX = tile.Texture.Width;
            int deltaY = tile.Texture.Height;

            for (int currentX = 0; currentX < windowWidth; currentX += tile.Texture.Width)
                for (int currentY = 0; currentY < windowHeight; currentY += tile.Texture.Height)
                    coordinates.Add(new Vector2(currentX, currentY));
            
            return coordinates;
        }

    }
}
