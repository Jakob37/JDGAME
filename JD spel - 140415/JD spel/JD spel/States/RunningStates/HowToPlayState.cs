using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace JD_spel
{
    public class HowToPlayState : RunningState
    {
        private Sprite spriteSheet;
        private SpriteFont font;
        private Gubbe gubbe;
        private int knappNerTryckt;
        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;
        private VanligFiende fiende1;
        

        public HowToPlayState(Game1 game, Sprite spriteSheet)
            : base(game)
        {
            this.spriteSheet = spriteSheet;
            font = game.Content.Load<SpriteFont>("howToPlayFont");
        }

        public override void Initialize()
        {
            base.Initialize();

            gubbe = new Gubbe(game, spriteSheet, this);
            spelObjektLista.Add(gubbe);
            knappNerTryckt = 0;
        }

        public override void Uppdatera(GameTime gameTime)
        {
            base.Uppdatera(gameTime);
            
            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();
            
            UppdateraListor(gameTime);
            AddEnemies();
            Escape();
            SpecialGubbeOptions();
        }
        private void SpecialGubbeOptions()
        {
            if (knappNerTryckt <= 3)
            {
                gubbe.liv = 20;
                gubbe.shield = 0;
            }

            if (knappNerTryckt >= 2 && knappNerTryckt <= 4 )
                fiende1.liv = 50;

            if (knappNerTryckt == 5)
                gubbe.skada = 1;
            if (knappNerTryckt == 6)
                gubbe.shield = 30;
        }
        private void Escape()
        {
            currentKeyboardState = Keyboard.GetState();
            if (currentKeyboardState.IsKeyDown(Keys.Escape))
            {
                game.runningState = game.menyState;
            }
        }
        private void UppdateraListor(GameTime gameTime)
        {
            //Går igenom alla spelobjekt
            foreach (SpelObjekt s in spelObjektLista)
            {
                s.Uppdatera(gameTime);
            }

            if (addObjektLista.Count > 0)
            {
                foreach (SpelObjekt s in addObjektLista)
                {
                    spelObjektLista.Add(s);
                }
            }
            addObjektLista.Clear();
        }
        private void AddEnemies()
        {
            if (knappNerTryckt == 2)
            {
                fiende1 = new VanligFiende(game, spriteSheet, gubbe, this);
                fiende1.Position = new Vector2(300, 300);
                spelObjektLista.Add(fiende1);
                fiende1.hastighet = 0;
                knappNerTryckt = 3;
            }
        }
        public override void Rita(SpriteBatch spriteBatch)
        {
            base.Rita(spriteBatch);
            
            
            foreach (SpelObjekt s in spelObjektLista)
            {
                s.Rita(spriteBatch);
            }

            if (knappNerTryckt == 0 && gubbe.lever)
            {
                spriteBatch.DrawString(font, "This is how you play League of Legends 2", new Vector2(200, 100), Color.Red);
                spriteBatch.DrawString(font, "Press Enter to continue", new Vector2(200, 130), Color.Red);
            }
            if (knappNerTryckt == 1 && gubbe.lever)
            {
                spriteBatch.DrawString(font, "You can move if you press up, down, left and right arrow", new Vector2(200, 100), Color.Red);
                spriteBatch.DrawString(font, "Press Enter to continue", new Vector2(200, 130), Color.Red);
            }
            if (knappNerTryckt == 3 && gubbe.lever)
            {
                spriteBatch.DrawString(font, "This is an enemy. It will try to kill you", new Vector2(200, 100), Color.Red);
                spriteBatch.DrawString(font, "Press Enter to continue", new Vector2(200, 130), Color.Red);
            }
            if (knappNerTryckt == 4 && gubbe.lever)
            {
                
                spriteBatch.DrawString(font, "Enemies attack in diferent wasys.", new Vector2(200, 100), Color.Red);
                spriteBatch.DrawString(font, "All enemies hurt you if you walk into them", new Vector2(200, 130), Color.Red);
                spriteBatch.DrawString(font, "When you gets hurt your liv goes down", new Vector2(200, 160), Color.Red);
                spriteBatch.DrawString(font, "Press Enter to continue", new Vector2(200, 190), Color.Red);
            }
            if (knappNerTryckt == 5 && gubbe.lever)
            {
                spriteBatch.DrawString(font, "You can defend yourself by shooting at it with left shift", new Vector2(200, 100), Color.Red);
                spriteBatch.DrawString(font, "Try to kill this enemy", new Vector2(200, 130), Color.Red);
                spriteBatch.DrawString(font, "Kill this enemy to continue", new Vector2(200, 160), Color.Red);
            }
            if (knappNerTryckt == 6 && gubbe.lever)
            {
                spriteBatch.DrawString(font, "Everytime you shoot your Energi will go down", new Vector2(200, 100), Color.Red);
                spriteBatch.DrawString(font, "If you run out of Energi can you not shoot", new Vector2(200, 130), Color.Red);
                spriteBatch.DrawString(font, "The energi will recharge over time", new Vector2(200, 160), Color.Red);
                spriteBatch.DrawString(font, "Press Enter to continue", new Vector2(200, 190), Color.Red);
            }
            if (knappNerTryckt == 7 && gubbe.lever)
            {
                spriteBatch.DrawString(font, "When you start a level you have 30 shield", new Vector2(200, 100), Color.Red);
                spriteBatch.DrawString(font, "All damage you take when you have a shield", new Vector2(200, 130), Color.Red);
                spriteBatch.DrawString(font, "will damage the shield insted", new Vector2(200, 160), Color.Red);
                spriteBatch.DrawString(font, "Press Enter to continue", new Vector2(200, 190), Color.Red);
            }
            if (knappNerTryckt == 8 && gubbe.lever)
            {
                spriteBatch.DrawString(font, "If you press Ctrl you make a new shield", new Vector2(200, 100), Color.Red);
                spriteBatch.DrawString(font, "That shield take 50 energi to make", new Vector2(200, 130), Color.Red);
                spriteBatch.DrawString(font, "but will also have 50 in shield", new Vector2(200, 160), Color.Red);
                spriteBatch.DrawString(font, "Use a shield to continue", new Vector2(200, 190), Color.Red);
            }
            if (knappNerTryckt == 9 && gubbe.lever)
            {
                spriteBatch.DrawString(font, "You have different weapons that you can shoot with", new Vector2(220, 100), Color.Red);
                spriteBatch.DrawString(font, "You switch weapon by pressing the numbers", new Vector2(220, 130), Color.Red);
                spriteBatch.DrawString(font, "Press Enter to continue", new Vector2(220, 160), Color.Red);
            }
            if (knappNerTryckt == 10 && gubbe.lever)
            {
                spriteBatch.DrawString(font, "Here is a list of all weapons", new Vector2(220, 100), Color.Red);
                spriteBatch.DrawString(font, "1. Basic Skott", new Vector2(220, 130), Color.Red);
                spriteBatch.DrawString(font, "Very low cost, Very low damage, full range", new Vector2(220, 160), Color.Red);
                spriteBatch.DrawString(font, "Good to kill one hit Enemies", new Vector2(220, 190), Color.Red);
                spriteBatch.DrawString(font, "2. Power Skott", new Vector2(220, 250), Color.Red);
                spriteBatch.DrawString(font, "High cost, High damage, medium range", new Vector2(220, 280), Color.Red);
                spriteBatch.DrawString(font, "Good to kill High health Enemies", new Vector2(220, 310), Color.Red);
                spriteBatch.DrawString(font, "3. Basic Laser", new Vector2(220, 370), Color.Red);
                spriteBatch.DrawString(font, "High cost, High damage, medium range", new Vector2(220, 400), Color.Red);
                spriteBatch.DrawString(font, "Good to kill many Enemies at once", new Vector2(220, 430), Color.Red);
                spriteBatch.DrawString(font, "Press Enter to continue", new Vector2(220, 460), Color.Red);
            }
            if (knappNerTryckt == 11 && gubbe.lever)
            {
                spriteBatch.DrawString(font, "4. Big Stone Skott", new Vector2(220, 130), Color.Red);
                spriteBatch.DrawString(font, "Very high cost, Very high damage, full range", new Vector2(220, 160), Color.Red);
                spriteBatch.DrawString(font, "Good to kill grouped enemies", new Vector2(220, 190), Color.Red);
                //spriteBatch.DrawString(font, "2. Power Skott", new Vector2(220, 250), Color.Red);
                //spriteBatch.DrawString(font, "High cost, High damage, medium range", new Vector2(220, 280), Color.Red);
                //spriteBatch.DrawString(font, "Good to kill High health Enemies", new Vector2(220, 310), Color.Red);
                //spriteBatch.DrawString(font, "3. Basic Laser", new Vector2(220, 370), Color.Red);
                //spriteBatch.DrawString(font, "High cost, High damage, medium range", new Vector2(220, 400), Color.Red);
                //spriteBatch.DrawString(font, "Good to kill many Enemies at once", new Vector2(220, 430), Color.Red);
                spriteBatch.DrawString(font, "Press Enter to continue", new Vector2(220, 460), Color.Red);
            }
            if (knappNerTryckt == 12 && gubbe.lever)
            {
                spriteBatch.DrawString(font, "Now is the tutorial done!!", new Vector2(220, 100), Color.Red);
                spriteBatch.DrawString(font, "You can always press Escape to go Back a Stage", new Vector2(220, 130), Color.Red);
            }


            if (knappNerTryckt >= 4 && gubbe.lever)
                spriteBatch.DrawString(font, "Liv: " + gubbe.liv.ToString(), new Vector2(50, 50), Color.Red);
            if (knappNerTryckt >= 6 && gubbe.lever)
                spriteBatch.DrawString(font, "Energi: " + gubbe.currentEnergi.ToString(), new Vector2(50, 70), Color.Blue);
            if (knappNerTryckt >= 7 && gubbe.lever)
                spriteBatch.DrawString(font, "Shield: " + gubbe.GetSpelarShield().ToString(), new Vector2(50, 90), Color.LightGreen);
            if (knappNerTryckt >= 9 && gubbe.lever)
                spriteBatch.DrawString(font, "Vapen: " + gubbe.GetSpelarMagi().ToString(), new Vector2(50, 110), Color.Yellow);
            if (!gubbe.lever)
            {
                spriteBatch.DrawString(font, "Oh No!!! You died!", new Vector2(200, 100), Color.Red);
                spriteBatch.DrawString(font, "Press Enter to revive again", new Vector2(200, 130), Color.Red);
            }
            if (currentKeyboardState.IsKeyDown(Keys.Enter) && previousKeyboardState.IsKeyUp(Keys.Enter) && !gubbe.lever)
            {
                gubbe.liv = 20;
                gubbe.lever = true;
            }

            if (currentKeyboardState.IsKeyDown(Keys.Enter) && knappNerTryckt == 0 && previousKeyboardState.IsKeyUp(Keys.Enter) && gubbe.lever)
                knappNerTryckt = 1;
            else if (currentKeyboardState.IsKeyDown(Keys.Enter) && knappNerTryckt == 1 && previousKeyboardState.IsKeyUp(Keys.Enter) && gubbe.lever)
                knappNerTryckt = 2;
            else if (currentKeyboardState.IsKeyDown(Keys.Enter) && knappNerTryckt == 3 && previousKeyboardState.IsKeyUp(Keys.Enter) && gubbe.lever)
                knappNerTryckt = 4;
            else if (currentKeyboardState.IsKeyDown(Keys.Enter) && knappNerTryckt == 4 && previousKeyboardState.IsKeyUp(Keys.Enter) && gubbe.lever)
                knappNerTryckt = 5;
            else if (knappNerTryckt == 5 && !fiende1.lever && gubbe.lever)
                knappNerTryckt = 6;
            else if (currentKeyboardState.IsKeyDown(Keys.Enter) && knappNerTryckt == 6 && previousKeyboardState.IsKeyUp(Keys.Enter) && gubbe.lever)
                knappNerTryckt = 7;
            else if (currentKeyboardState.IsKeyDown(Keys.Enter) && knappNerTryckt == 7 && previousKeyboardState.IsKeyUp(Keys.Enter) && gubbe.lever)
                knappNerTryckt = 8;
            else if (gubbe.shield == 50 && knappNerTryckt == 8 && gubbe.lever)
                knappNerTryckt = 9;
            else if (currentKeyboardState.IsKeyDown(Keys.Enter) && knappNerTryckt == 9 && previousKeyboardState.IsKeyUp(Keys.Enter) && gubbe.lever)
                knappNerTryckt = 10;
            else if (currentKeyboardState.IsKeyDown(Keys.Enter) && knappNerTryckt == 10 && previousKeyboardState.IsKeyUp(Keys.Enter) && gubbe.lever)
                knappNerTryckt = 11;
        }
    }
}
