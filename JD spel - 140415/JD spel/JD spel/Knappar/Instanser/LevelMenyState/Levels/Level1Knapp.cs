using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class Level1Knapp : LevelKnapp
    {
        public Level1Knapp(Game1 game, Sprite spriteSheet, Vector2 position, Level level)
            : base(game, spriteSheet, position, level)
        {
            displaySprite = spriteSheet.GetSubSprite(new Rectangle(80, 50, 50, 30));
        }
    }
}
