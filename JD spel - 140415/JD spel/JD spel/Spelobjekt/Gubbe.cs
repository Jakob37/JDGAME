using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace JD_spel
{
    public enum SpelarMagi 
    {
        BasicSkott,
        PowerSkott,
        BasicLaser,
        BigStoneSkott
    }
    class Gubbe : SpelObjekt
    {
        private int maxhastighet;
        private int maxEnergi;
        public int currentEnergi;
        private int loadEnergi;
        private int loadEnergiTimer;
        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;
        private SpelarMagi valdMagi;
        public SpelarMagi GetSpelarMagi() { return valdMagi; }
        public float shield;
        public float GetSpelarShield() { return shield; }
        
        //private Boolean summon;

        //Konstruktor, som körs när gubben skapas
        public Gubbe(Game1 game, Sprite spriteSheet, State presentState) : base(game, spriteSheet, presentState)
        {
            this.game = game;

            hastighet = 5;
            Position = new Vector2(200, 200);
            lever = true;
            maxhastighet = 4;
            

            bild = spriteSheet.GetSubSprite(new Rectangle(25, 0, 15, 29));
            skada = 1;
            liv = 20;
            maxEnergi = 100;
            currentEnergi = 100;
            loadEnergi = 5;
            valdMagi = SpelarMagi.BasicSkott;
            shield = 30;
            riktning = new Vector2(1, 0);
            drawLayer = 0.5f;
            //summon = false;
        }

        //Funktioner
        public override void Uppdatera(GameTime gameTime)
        {
            base.Uppdatera(gameTime);
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            if (currentKeyboardState.IsKeyDown(Keys.D1))
                valdMagi = SpelarMagi.BasicSkott;
            else if (currentKeyboardState.IsKeyDown(Keys.D2))
                valdMagi = SpelarMagi.PowerSkott;
            else if (currentKeyboardState.IsKeyDown(Keys.D3))
                valdMagi = SpelarMagi.BasicLaser;
            else if (currentKeyboardState.IsKeyDown(Keys.D4))
                valdMagi = SpelarMagi.BigStoneSkott;


            UppdateraGubbensPosition();
            GubbensPositionMotKanter();
            EnergiReg(gameTime);
            GubbeSkjuter(valdMagi);
            GubbeShield();
        }
        
        //Skjuter skott
        private void GubbeShield()
        {
            int energiCost = 50;
            if (currentKeyboardState.IsKeyDown(Keys.LeftControl) && currentEnergi >= energiCost && previousKeyboardState.IsKeyUp(Keys.LeftControl))
            {
                currentEnergi -= energiCost;
                shield = 50;
            }
        }

        private void GubbeSkjuter(SpelarMagi magi)
        {
            switch (magi)
            {
                case SpelarMagi.BasicSkott:
                    {
                        BasicSkott();
                        break;
                    }
                case SpelarMagi.PowerSkott:
                    {
                        PowerSkott();
                        break;
                    }
                case SpelarMagi.BasicLaser:
                    {
                        BasicLaser();
                        break;
                    }
                case SpelarMagi.BigStoneSkott:
                    {
                        BigStoneSkott();
                        break;
                    }
            }
            
        }
        private void BasicSkott()
        { 
            int energiCost = 2;
            if (currentKeyboardState.IsKeyDown(Keys.LeftShift) && previousKeyboardState.IsKeyUp(Keys.LeftShift) && lever
                 && currentEnergi >= energiCost)
            {
                BasicSkott s = new BasicSkott(game, spriteSheet, presentState);
                s.SkjutSkott(this, riktning);
                presentState.addObjektLista.Add(s);
                currentEnergi -= energiCost;
            }
        }
        private void PowerSkott()
        {
            int energiCost = 5;
            if (currentKeyboardState.IsKeyDown(Keys.LeftShift) && previousKeyboardState.IsKeyUp(Keys.LeftShift) && lever
                 && currentEnergi >= energiCost)
            {
                PowerSkott s = new PowerSkott(game, spriteSheet, presentState);
                s.SkjutSkott(this, riktning);
                presentState.addObjektLista.Add(s);
                currentEnergi -= energiCost;
            }
        }
        private void BasicLaser()
        {
            int energiCost = 1;
            if (currentKeyboardState.IsKeyDown(Keys.LeftShift) && lever && currentEnergi >= energiCost)
            {
                BasicLaser s = new BasicLaser(game, spriteSheet, presentState);
                s.SkjutSkott(this, riktning);
                presentState.addObjektLista.Add(s);
                currentEnergi -= energiCost;
            }
        }
        private void BigStoneSkott()
        {
            int energiCost = 25;
            if (currentKeyboardState.IsKeyDown(Keys.LeftShift) && previousKeyboardState.IsKeyUp(Keys.LeftShift) && lever
                 && currentEnergi >= energiCost)
            {
                BigStoneSkott s = new BigStoneSkott(game, spriteSheet, presentState);
                s.SkjutSkott(this, riktning);
                presentState.addObjektLista.Add(s);
                currentEnergi -= energiCost;
            }
        }
        public void UppdateraGubbensPosition()
        {
            
            if (currentKeyboardState.IsKeyDown(Keys.Right))
            {
                riktning.X = 1;
                hastighet = maxhastighet;
            }
            if (currentKeyboardState.IsKeyDown(Keys.Left))
            {
                riktning.X = -1;
                hastighet = maxhastighet;
            }
            if (currentKeyboardState.IsKeyDown(Keys.Up))
            {
                riktning.Y = -1;
                hastighet = maxhastighet;
            }
            if (currentKeyboardState.IsKeyDown(Keys.Down))
            {
                riktning.Y = 1;
                hastighet = maxhastighet;
            }
            if (currentKeyboardState.IsKeyUp(Keys.Up)
                && currentKeyboardState.IsKeyUp(Keys.Down)
                && currentKeyboardState.IsKeyUp(Keys.Right)
                && currentKeyboardState.IsKeyUp(Keys.Left))
            {
                hastighet = 0;
            }
            if ((currentKeyboardState.IsKeyDown(Keys.Up) || currentKeyboardState.IsKeyDown(Keys.Down))
                 && (currentKeyboardState.IsKeyUp(Keys.Left) && currentKeyboardState.IsKeyUp(Keys.Right)))
            {
                riktning.X = 0;
            }
            if ((currentKeyboardState.IsKeyDown(Keys.Right) || currentKeyboardState.IsKeyDown(Keys.Left))
                && (currentKeyboardState.IsKeyUp(Keys.Up) && currentKeyboardState.IsKeyUp(Keys.Down)))
            {
                riktning.Y = 0;
            }

        }

        public void GubbensPositionMotKanter()
        {
            float WindowWidth = game.Window.ClientBounds.Width;
            float WindowHeight = game.Window.ClientBounds.Height;

            if (PositionX < 0)
            {
                PositionX = 0;
            }
            if (PositionX > WindowWidth - bild.Width)
            {
                PositionX = WindowWidth - bild.Width;
            }
            
            if (Position.Y < 0)
            {
                PositionY = 0;
            }
            
            if (PositionY > WindowHeight - bild.Height)
            {
                PositionY = WindowHeight - bild.Height;
            }
        }

        private void EnergiReg(GameTime gameTime)
        {
            loadEnergiTimer += gameTime.ElapsedGameTime.Milliseconds;
            if (loadEnergiTimer >= 1000)
            {
                currentEnergi += loadEnergi;
                loadEnergiTimer = 0;
            }

            if (currentEnergi >= maxEnergi)
            {
                currentEnergi = maxEnergi;
            }

        }

        public override void SkadaObjekt(float skada)
        {
            
            if (shield > 0)
                shield -= skada;

            else
                liv -= skada;

            if (shield < 0)
                shield = 0;
        }
    }
}