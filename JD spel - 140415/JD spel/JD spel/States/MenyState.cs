using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace JD_spel
{
    public class MenyState : State
    {
        private Sprite spriteSheet;
        private List<Clickable> knappar;
        private SpriteFont font;

        private int textTimer;
        
        public MenyState(Game1 game, Sprite spriteSheet)
            : base(game)
        {
            this.spriteSheet = spriteSheet;
            font = game.Content.Load<SpriteFont>("menyFont");

            knappar = new List<Clickable>();

            StartKnapp start = new StartKnapp(game, spriteSheet, new Vector2(410, 200));
            start.Initialize();

            ExitKnapp exit = new ExitKnapp(game, spriteSheet, new Vector2(410, 550));
            exit.Initialize();

            HowToPlayKnapp howToPlay = new HowToPlayKnapp(game, spriteSheet, new Vector2(410, 350));
            howToPlay.Initialize();
            
            knappar.Add(start);
            knappar.Add(exit);
            knappar.Add(howToPlay);

            textTimer = 0;
        }

        public override void Initialize()
        {
            
        }

        public override void Uppdatera(GameTime gameTime)
        {
            base.Uppdatera(gameTime);

            foreach (Clickable knapp in knappar)
            {
                knapp.Update(gameTime);
            }

            textTimer += gameTime.ElapsedGameTime.Milliseconds;
        }

        public override void Rita(SpriteBatch spriteBatch)
        {
            base.Rita(spriteBatch);

            if (textTimer > 2000 && textTimer < 5000)
                spriteBatch.DrawString(font, "League of Legends 2", new Vector2(200, 100), Color.DarkSlateGray);
            
            foreach (Clickable knapp in knappar)
            {
                knapp.Draw(spriteBatch);
            }
        }
    }
}
