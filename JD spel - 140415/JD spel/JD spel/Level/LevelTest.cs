using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class LevelTest : Level
    {
        public LevelTest(Game1 game, Sprite spriteSheet, Random random1)
            : base()
        {
            spelObjektLista = new List<SpelObjekt>();

            StoneTowerBoss f1 = new StoneTowerBoss(game, spriteSheet);
            f1.Position = new Vector2(300, 300);
            spelObjektLista.Add(f1);

        }

    }
}
