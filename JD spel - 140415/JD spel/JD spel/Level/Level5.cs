using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class Level5 : Level
    {

        public Level5(Game1 game, Sprite spriteSheet, Random random1)
            : base()
        {
            spelObjektLista = new List<SpelObjekt>();

            StoneTower torn1 = new StoneTower(game, spriteSheet);
            torn1.Position = new Vector2(300, 300);
            spelObjektLista.Add(torn1);
            StoneTower torn2 = new StoneTower(game, spriteSheet);
            torn2.Position = new Vector2(700, 300);
            spelObjektLista.Add(torn2);
            StoneTower torn3 = new StoneTower(game, spriteSheet);
            torn3.Position = new Vector2(300, 500);
            spelObjektLista.Add(torn3);
            StoneTower torn4 = new StoneTower(game, spriteSheet);
            torn4.Position = new Vector2(700, 500);
            spelObjektLista.Add(torn4);
        }

    }
}
