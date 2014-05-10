using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

/* Smarta kortkommandon:
 * Håller du ned Ctrl, och sedan trycker först M och sedan O minimerar du alla funktioner.
 * 
 * To be continued...
 */

namespace JD_spel
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        //Här berättar du vilka variabler du vill använda

        //Spelvariabler
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Sprite spriteSheet;
        private SpriteFont font;

        //Denna state är den som körs av spelet, sätts till
        //någon existerande state
        public State runningState;

        public LevelState levelState;
        public MenyState menyState;
        public HowToPlayState howToPlayState;
        public LevelMenyState levelMenyState;

        private Song happySong;

        //Detta körs när spelet skapas
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        //Detta sätter spelets startvärden
        protected override void Initialize()
        {
            base.Initialize();
            IsMouseVisible = true;

            spriteSheet = new Sprite(this.Content.Load<Texture2D>("FirstSpriteSheet"));
            font = this.Content.Load<SpriteFont>("vanligFont");

            graphics.PreferredBackBufferWidth = 900;
            graphics.PreferredBackBufferHeight = 700;
            graphics.ApplyChanges();

            levelState = new LevelState(this, spriteSheet);
            levelState.Initialize();

            menyState = new MenyState(this, spriteSheet);
            menyState.Initialize();

            howToPlayState = new HowToPlayState(this, spriteSheet);
            howToPlayState.Initialize();

            levelMenyState = new LevelMenyState(this, spriteSheet);
            levelMenyState.Initialize();

            runningState = menyState;
        }


        //Här laddas t ex bilder och musik in
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            happySong = Content.Load<Song>("HappySong");
        }

        //Denna kommer vi inte använda nu.
        protected override void UnloadContent()
        {
        }

        //Detta körs varje gång spelet uppdateras. Spelet uppdateras ca 60 gånger i sekunden.
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            runningState.Uppdatera(gameTime);

            KeyboardState currentKeyboard = Keyboard.GetState();
            if (currentKeyboard.IsKeyDown(Keys.M))
            {
                MediaPlayer.Play(happySong);
                MediaPlayer.IsRepeating = true;
            }
        }

        //Detta anropas varje gång spelet uppdaterats. Här finns logik som berättar hur spelet ska ritas upp.
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);
            base.Draw(gameTime);

            //Mellan .Begin() och .End() ritas allt i spelet upp för varje frame
            spriteBatch.Begin();

            runningState.Rita(spriteBatch);

            spriteBatch.End();
        }

    }
}










