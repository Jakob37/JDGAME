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
 * H�ller du ned Ctrl, och sedan trycker f�rst M och sedan O minimerar du alla funktioner.
 * 
 * To be continued...
 */

namespace JD_spel
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        //H�r ber�ttar du vilka variabler du vill anv�nda

        //Spelvariabler
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private Sprite spriteSheet;
        private SpriteFont font;

        //Denna state �r den som k�rs av spelet, s�tts till
        //n�gon existerande state
        public State runningState;

        public LevelState levelState;
        public MenyState menyState;
        public HowToPlayState howToPlayState;
        public LevelMenyState levelMenyState;

        private Song happySong;

        private Boolean isMusicRunning;

        public Gubbe Player1;

        //Detta k�rs n�r spelet skapas
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        //Detta s�tter spelets startv�rden
        protected override void Initialize()
        {
            base.Initialize();
            IsMouseVisible = true;

            spriteSheet = new Sprite(this.Content.Load<Texture2D>("FirstSpriteSheet"));
            
            font = this.Content.Load<SpriteFont>("vanligFont");

            graphics.PreferredBackBufferWidth = 900;
            graphics.PreferredBackBufferHeight = 700;
            graphics.ApplyChanges();

            Player1 = new Gubbe(this, spriteSheet);

            levelState = new LevelState(this, spriteSheet);
            levelState.Initialize();

            menyState = new MenyState(this, spriteSheet);
            menyState.Initialize();

            howToPlayState = new HowToPlayState(this, spriteSheet);
            howToPlayState.Initialize();

            levelMenyState = new LevelMenyState(this, spriteSheet);
            levelMenyState.Initialize();

            runningState = menyState;

            isMusicRunning = true;
            ControlMusic(isMusicRunning);

        }


        //H�r laddas t ex bilder och musik in
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            happySong = Content.Load<Song>("HappySong");
            //happySong = Content.Load<Song>("TheBossSong");
        }

        //Denna kommer vi inte anv�nda nu.
        protected override void UnloadContent()
        {
        }

        //Detta k�rs varje g�ng spelet uppdateras. Spelet uppdateras ca 60 g�nger i sekunden.
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            runningState.Uppdatera(gameTime);

            ControlManager.Uppdatera(gameTime);

            if (ControlManager.IsKeyPressed(Keys.M))
            {
                isMusicRunning = ToggleBoolean(isMusicRunning);
                ControlMusic(isMusicRunning);
            }
        }

        private void ControlMusic(Boolean isMusicRunning)
        {
            if (isMusicRunning)
            {
                MediaPlayer.Play(happySong);
                MediaPlayer.IsRepeating = true;
            }
            else
            {
                MediaPlayer.Pause();
            }
        }

        private Boolean ToggleBoolean(Boolean oldValue)
        {
            if (oldValue == false)
                return true;
            else
                return false;
        }

        //Detta anropas varje g�ng spelet uppdaterats. H�r finns logik som ber�ttar hur spelet ska ritas upp.
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);
            base.Draw(gameTime);

            //Mellan .Begin() och .End() ritas allt i spelet upp f�r varje frame
            spriteBatch.Begin(SpriteSortMode.FrontToBack, BlendState.AlphaBlend);

            runningState.Rita(spriteBatch);
            
            spriteBatch.End();
        }

    }
}










