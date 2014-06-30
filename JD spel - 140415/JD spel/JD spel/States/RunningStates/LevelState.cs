using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace JD_spel
{
    public class LevelState : RunningState
    {
        private enum PlayState {
            running,
            win,
            fail
        }

        private Sprite spriteSheet;
        private Gubbe gubbe;

        private KeyboardState currentKeyboardState;
        private Random random1;

        private SpriteFont font;
        private BackgroundSprite backgroundSprite;

        private PlayState playState;

        private Level currentLevel;

        public LevelState(Game1 game, Sprite spriteSheet)
            : base(game)
        {
            this.spriteSheet = spriteSheet;
            font = game.Content.Load<SpriteFont>("vanligFont");
            random1 = new Random();

            Sprite tile = new Sprite(game.Content.Load<Texture2D>("Tiles/MudTile"));
            backgroundSprite = new BackgroundSprite(game.Window.ClientBounds.Width, game.Window.ClientBounds.Height, tile);

            playState = PlayState.running;
        }

        public override void Initialize()
        { 
            base.Initialize();

            playState = PlayState.running;
            spelObjektLista.Clear();
            gubbe = game.Player1;
            gubbe.Initialize(this);
            spelObjektLista.Add(gubbe);
        }

        public void MakeLevel(Level level)
        {
            spelObjektLista.AddRange(level.GetLevel());
            currentLevel = level;
        }

        public override void Uppdatera(GameTime gameTime)
        {
            switch (playState)
            {
                case PlayState.running:
                    {
                        base.Uppdatera(gameTime);
                        CheckRunningStatus();
                        break;
                    }
                case PlayState.win:
                    {
                        WinLogic();
                        break;
                    }
                case PlayState.fail:
                    {
                        FailLogic();
                        break;
                    }
            }

            Escape();
        }

        private void CheckRunningStatus()
        {
            if (!gubbe.lever)
            {
                playState = PlayState.fail;
                currentLevel.MarkFail();
            }
            else if (HasWon())
            {
                playState = PlayState.win;
                currentLevel.MarkWin();
            }
        }

        private Boolean HasWon()
        {
            foreach (SpelObjekt obj in spelObjektLista)
            {
                if (obj is Fiende)
                {
                    return false;
                }
            }

            return true;
        }

        private void WinLogic()
        { }

        private void FailLogic()
        { }


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
            spriteBatch.DrawString(font, "Liv: " + gubbe.liv.ToString(), new Vector2(30, 30), Color.Red, .0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
            spriteBatch.DrawString(font, "Energi: " + gubbe.currentEnergi.ToString(), new Vector2(30, 50), Color.Blue, .0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
            spriteBatch.DrawString(font, "Shield: " + gubbe.GetSpelarShield().ToString(), new Vector2(30, 70), Color.LightGreen, .0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
            spriteBatch.DrawString(font, "Vapen: " + gubbe.GetSpelarMagi().ToString(), new Vector2(30, 90), Color.Yellow, .0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);

            if (playState == PlayState.fail)
            {
                spriteBatch.DrawString(font, "YOU LOSE\nPress Escape to return to menu", new Vector2(200, 200), Color.Red, .0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);    
            }

            if (playState == PlayState.win)
            {
                spriteBatch.DrawString(font, "YOU WIN\nPress Escape to return to menu", new Vector2(400, 300), Color.Red, .0f, Vector2.Zero, 1f, SpriteEffects.None, 1f);
            }
        }   
    }
}
