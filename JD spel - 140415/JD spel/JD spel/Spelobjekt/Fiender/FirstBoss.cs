﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace JD_spel
{
    class FirstBoss : Fiende
    {
        private KeyboardState keyboardState;
        private int skjutTimer1;
        private int minTimer;
        private int skjutTimer2;
        private int antalSkottKvar;
        public FirstBoss(Game1 game, Sprite spriteSheet, Gubbe gubbe, State presentState)
            : base(game, spriteSheet, gubbe, presentState)
        {
            //importera ny spriteSheet
            bild = spriteSheet.GetSubSprite(new Rectangle(142, 2, 32, 35));
            //bild = spriteSheet.GetSubSprite(new Rectangle(117, 0, 18, 27));
            hastighet = 2F;
            movement = FiendeMovement.Follow;
            liv = 500;
            skada = 1;

            Random random = new Random();
            riktning = new Vector2((float)(random.NextDouble() * 2 - 1),
                (float)(random.NextDouble() * 2 - 1));
            riktning = GlobalFunctions.ScaleDirection(riktning);
        }
        public override void Uppdatera(GameTime gameTime)
        {
            base.Uppdatera(gameTime);
            keyboardState = Keyboard.GetState();
            Skjuta(gameTime);
            PlaceMine(gameTime);
        }
        private void Skjuta(GameTime gameTime)
        {
            skjutTimer1 += gameTime.ElapsedGameTime.Milliseconds;
            skjutTimer2 += gameTime.ElapsedGameTime.Milliseconds;
            if (keyboardState.IsKeyDown(Keys.LeftShift) && lever && skjutTimer1 >= 500 && antalSkottKvar <= 0)
            {
                antalSkottKvar = 3;
                skjutTimer1 = 0;
            }
            if (antalSkottKvar >=1 && skjutTimer2 >= 75)
            {
                FiendeSkott s = new FiendeSkott(game, spriteSheet, presentState);
                s.SkjutSkott(position, riktning);
                game.levelState.addObjektLista.Add(s);
                skjutTimer2 = 0;
                antalSkottKvar -= 1;
            }
            
        }
        private void PlaceMine(GameTime gameTime)
        {
            minTimer += gameTime.ElapsedGameTime.Milliseconds;
            if (lever && minTimer >= 2000)
            {
                Mina s = new Mina(game, spriteSheet, gubbe, presentState);
                s.position = position;
                game.levelState.addObjektLista.Add(s);
                minTimer = 0;
            }
        }
    }
}