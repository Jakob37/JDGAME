using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JD_spel
{
    public class LevelState : State
    {
        private Sprite spriteSheet;
        private Gubbe gubbe;

        private KeyboardState currentKeyboardState;
        private Random random1;

        private SpriteFont font;
        private BackgroundSprite backgroundSprite;

        public LevelState(Game1 game, Sprite spriteSheet)
            : base(game)
        {
            this.spriteSheet = spriteSheet;
            font = game.Content.Load<SpriteFont>("vanligFont");
            random1 = new Random();

            Sprite tile = new Sprite(game.Content.Load<Texture2D>("Tiles/MudTile"));
            backgroundSprite = new BackgroundSprite(game.Window.ClientBounds.Width, game.Window.ClientBounds.Height, tile);
        }

        public override void Initialize()
        { 
            base.Initialize();

            gubbe = new Gubbe(game, spriteSheet, this);
            spelObjektLista.Add(gubbe);
        }

        public void SetLevel(int level)
        {
            switch (level)
            {
                case 1:
                    {
                        MakeLevel1();
                        break;
                    }
                case 2:
                    {
                        MakeLevel2();
                        break;
                    }
                case 3:
                    {
                        MakeLevel3();
                        break;
                    }
                case 4:
                    {
                        MakeLevel4();
                        break;
                    }
                case 5:
                    {
                        MakeLevel5();
                        break;
                    }
            }
        }

        #region MakeLevel
        private void MakeLevel1()
        {
            //FiendeTorn
            FiendeTorn torn1 = new FiendeTorn(game, spriteSheet, gubbe, this);
            torn1.position = new Vector2(300, 300);
            spelObjektLista.Add(torn1);
            FiendeTorn torn2 = new FiendeTorn(game, spriteSheet, gubbe, this);
            torn2.position = new Vector2(700, 300);
            spelObjektLista.Add(torn2);
            FiendeTorn torn3 = new FiendeTorn(game, spriteSheet, gubbe, this);
            torn3.position = new Vector2(300, 500);
            spelObjektLista.Add(torn3);
            FiendeTorn torn4 = new FiendeTorn(game, spriteSheet, gubbe, this);
            torn4.position = new Vector2(700, 500);
            spelObjektLista.Add(torn4);

            //VanligFiende
            
            for (int n = 0; n < 10; n++)
            {
                VanligFiende f1 = new VanligFiende(game, spriteSheet, gubbe, this);
                f1.position = new Vector2(random1.Next(870), random1.Next(670));
                spelObjektLista.Add(f1);
            }

            //MinGubbe
            Random random2 = new Random();
            for (int n = 0; n < 5; n++)
            {
                MinFiende f1 = new MinFiende(game, spriteSheet, gubbe, this);
                f1.position = new Vector2(random2.Next(870), random2.Next(670));
                spelObjektLista.Add(f1);
            }
        }

        private void MakeLevel2()
        {
            //Boss
            Random random1 = new Random();
            FirstBoss f1 = new FirstBoss(game, spriteSheet, gubbe, this);
            f1.position = new Vector2(random1.Next(870), random1.Next(670));
            spelObjektLista.Add(f1);
            
        }

        private void MakeLevel3()
        {
            //VanligFiende
        
            for (int n = 0; n < 50; n++)
            {
                VanligFiende f1 = new VanligFiende(game, spriteSheet, gubbe, this);
                f1.position = new Vector2(random1.Next(870), random1.Next(670));
                f1.SetRandomDirection(random1);
                spelObjektLista.Add(f1);
            }
        }
        

        private void MakeLevel4()
        {
            for (int n = 0; n < 10; n++)
            {
                FiendeMyra myra = new FiendeMyra(game, spriteSheet, gubbe, this);
                myra.position = new Vector2(random1.Next(870), random1.Next(670));
                myra.SetExternalRandom(random1);
                myra.SetRandomDirection();
                spelObjektLista.Add(myra);
            }

            FiendeMyrEgg egg = new FiendeMyrEgg(game, spriteSheet, gubbe, this);
            egg.position = new Vector2(300, 300);
            spelObjektLista.Add(egg);
        }

        private void MakeLevel5()
        {
            StoneTower torn1 = new StoneTower(game, spriteSheet, gubbe, this);
            torn1.position = new Vector2(300, 300);
            spelObjektLista.Add(torn1);
            StoneTower torn2 = new StoneTower(game, spriteSheet, gubbe, this);
            torn2.position = new Vector2(700, 300);
            spelObjektLista.Add(torn2);
            StoneTower torn3 = new StoneTower(game, spriteSheet, gubbe, this);
            torn3.position = new Vector2(300, 500);
            spelObjektLista.Add(torn3);
            StoneTower torn4 = new StoneTower(game, spriteSheet, gubbe, this);
            torn4.position = new Vector2(700, 500);
            spelObjektLista.Add(torn4);
        }
        #endregion

        public override void Uppdatera(GameTime gameTime)
        {
            base.Uppdatera(gameTime);
            Escape();
        }

        private void Escape()
        {
            currentKeyboardState = Keyboard.GetState();
            if (currentKeyboardState.IsKeyDown(Keys.Escape))
            {
                game.runningState = game.levelMenyState;
            }
        }

        public override void Rita(SpriteBatch spriteBatch)
        {
            backgroundSprite.Draw(spriteBatch);

            base.Rita(spriteBatch);

            //Skriv saker
            spriteBatch.DrawString(font, "Liv: " + gubbe.liv.ToString(), new Vector2(50, 50), Color.Red);
            spriteBatch.DrawString(font, "Energi: " + gubbe.currentEnergi.ToString(), new Vector2(50, 70), Color.Blue);
            spriteBatch.DrawString(font, "Shield: " + gubbe.GetSpelarShield().ToString(), new Vector2(50, 90), Color.LightGreen);
            spriteBatch.DrawString(font, "Vapen: " + gubbe.GetSpelarMagi().ToString(), new Vector2(50, 110), Color.Yellow);
        }

        
    }
}
