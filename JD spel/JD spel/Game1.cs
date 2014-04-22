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
        private KeyboardState currentKeyboardState;
        private KeyboardState previousKeyboardState;

        private Sprite spriteSheet;

        //Gubbvariabler

        private Gubbe gubbe;

        //fiendevariabler
        private Fiende fiende;

        //skottvariabler
        private List<Skott> skottLista = new List<Skott>();

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

            gubbe = new Gubbe(this, spriteSheet);
            fiende = new Fiende(this, spriteSheet, gubbe);

            graphics.PreferredBackBufferWidth = 900;
            graphics.PreferredBackBufferHeight = 700;
            graphics.ApplyChanges();
        }

        //H�r laddas t ex bilder och musik in
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        //Denna kommer vi inte anv�nda nu.
        protected override void UnloadContent()
        {
        }



        //Detta k�rs varje g�ng spelet uppdateras. Spelet uppdateras ca 60 g�nger i sekunden.
        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            previousKeyboardState = currentKeyboardState;
            currentKeyboardState = Keyboard.GetState();

            gubbe.Uppdatera(gameTime);
            fiende.Uppdatera(gameTime);
            foreach (Skott s in skottLista)
            {
                s.Uppdatera(gameTime);
            }
            if (ObjektKolliderar(gubbe.GetKanter(), fiende.GetKanter()) && fiende.fiendeLever)
            {
                gubbe.gubbeLever = false;
            }

            //skjuter skott
            if (currentKeyboardState.IsKeyDown(Keys.Space) && previousKeyboardState.IsKeyUp(Keys.Space) && gubbe.gubbeLever)
            {
                Skott s = new Skott(this, spriteSheet);
                s.SkjutSkott(gubbe.gubbPosition, gubbe.gubbRiktning);
                skottLista.Add(s);
            }
            //d�da fiende vid kollision
            foreach (Skott s in skottLista)
            {
                if (ObjektKolliderar(s.GetKanter(), fiende.GetKanter()) && s.lever)
                {
                    fiende.liv -= 1;
                    s.lever = false;

                }
            }
        }

        //Detta anropas varje g�ng spelet uppdaterats. H�r finns logik som ber�ttar hur spelet ska ritas upp.
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Green);
            base.Draw(gameTime);

            spriteBatch.Begin();
            gubbe.Rita(spriteBatch);

            fiende.Rita(spriteBatch);
            //fiende.Rita(spriteBatch);
          
            foreach (Skott s in skottLista)
            {
                s.Rita(spriteBatch);
            }
            spriteBatch.End();


        }

        //public Boolean ObjektKolliderar(Vector2 obj1Pos, Texture2D obj1Bild, Vector2 obj2Pos, Texture2D obj2Bild)
        //{
        //    Rectangle obj1Kanter = new Rectangle((int)obj1Pos.X, (int)obj1Pos.Y, obj1Bild.Width, obj1Bild.Height);
        //    Rectangle obj2Kanter = new Rectangle((int)obj2Pos.X, (int)obj2Pos.Y, obj2Bild.Width, obj2Bild.Height);
        
        //    if (obj1Kanter.Intersects(obj2Kanter))
        //    {
        //        return true;
        //    }
        
        //    else
        //    {
        //        return false;
        //    }
        
        //}

        public Boolean ObjektKolliderar(Rectangle obj1Kanter, Rectangle obj2Kanter)
        {
            //Rectangle obj1Kanter = new Rectangle((int)obj1Pos.X, (int)obj1Pos.Y, obj1Bild.Width, obj1Bild.Height);
            //Rectangle obj2Kanter = new Rectangle((int)obj2Pos.X, (int)obj2Pos.Y, obj2Bild.Width, obj2Bild.Height);
        
            if (obj1Kanter.Intersects(obj2Kanter))
            {
                return true;
            }
        
            else
            {
                return false;
            }
        
        }
  
    
    }
}