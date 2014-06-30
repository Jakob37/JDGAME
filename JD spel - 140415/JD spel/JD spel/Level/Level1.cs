using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace JD_spel
{
    class Level1 : Level
    {

        public Level1(Game1 game, Sprite spriteSheet, Random random1)
            : base()
        {
            spelObjektLista = new List<SpelObjekt>();

            //FiendeTorn
            FiendeTorn torn1 = new FiendeTorn(game, spriteSheet);
            torn1.Position = new Vector2(300, 300);
            spelObjektLista.Add(torn1);
            FiendeTorn torn2 = new FiendeTorn(game, spriteSheet);
            torn2.Position = new Vector2(700, 300);
            spelObjektLista.Add(torn2);
            FiendeTorn torn3 = new FiendeTorn(game, spriteSheet);
            torn3.Position = new Vector2(300, 500);
            spelObjektLista.Add(torn3);
            FiendeTorn torn4 = new FiendeTorn(game, spriteSheet);
            torn4.Position = new Vector2(700, 500);
            spelObjektLista.Add(torn4);

            //VanligFiende
            for (int n = 0; n < 10; n++)
            {
                VanligFiende f1 = new VanligFiende(game, spriteSheet);
                f1.Position = new Vector2(random1.Next(870), random1.Next(670));
                spelObjektLista.Add(f1);
            }

            //MinGubbe
            Random random2 = new Random();
            for (int n = 0; n < 5; n++)
            {
                MinFiende f1 = new MinFiende(game, spriteSheet);
                f1.Position = new Vector2(random2.Next(870), random2.Next(670));
                spelObjektLista.Add(f1);
            }
        }

    }
}
