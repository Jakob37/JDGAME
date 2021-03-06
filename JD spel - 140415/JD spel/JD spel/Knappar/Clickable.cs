﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Text.RegularExpressions;

namespace JD_spel
{
    //Super-class to all clickable objects.
    //Contains basic drawing logic, and basic mousedetection logic.
    public abstract class Clickable
    {
        #region declaration
        protected Vector2 position;
        protected Sprite spriteSheet;

        protected Sprite displaySprite;
        protected Sprite enabled;
        protected Sprite disabled;

        protected SpriteFont standardFont;
        protected SpriteFont displayFont;
        
        protected String displayText;
        protected Color color;

        protected Rectangle collisionZone;
        protected Vector2 offset;

        private MouseState previousMouse;
        private MouseState currentMouse;
        #endregion

        //Called if clickable is shown with Sprite
        public Clickable(Sprite spriteSheet, Vector2 position)
        {
            this.position = position;
            this.spriteSheet = spriteSheet;
            color = Color.White;
            offset = new Vector2(0, 0);

        }

        //Called if clickable is shown with text
        public Clickable(Vector2 position)
        {
            this.position = position;
            color = Color.DarkGreen;
            offset = new Vector2(0, 0);

            SetCollisionZone(0);
        }

        public virtual void Initialize()
        {
            SetCollisionZone(0);
        }

        private void SetCollisionZone(int currentOffset)
        {
            if (displaySprite != null)
            {
                collisionZone = new Rectangle((int)(position.X + offset.X), (int)(position.Y + offset.Y), displaySprite.Width, displaySprite.Height);
            }
            else
            {
                int zoneSize = 20;
                collisionZone = new Rectangle((int)position.X, (int)position.Y, zoneSize, zoneSize);
            }
        }

        public virtual void Update(GameTime gameTime)
        {
            previousMouse = currentMouse;
            currentMouse = Mouse.GetState();
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            if (displaySprite != null)
            {
                spriteBatch.Draw(displaySprite.Texture, 
                    position + offset, 
                    displaySprite.SourceRectangle, 
                    color,
                    0.0f,
                    Vector2.Zero,
                    1f,
                    SpriteEffects.None,
                    0.5f
                    );
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch, SpriteFont font)
        {
            if (displayText != null)
            {
                if (font != null)
                    spriteBatch.DrawString(font, displayText, position + offset, color);
                else
                    spriteBatch.DrawString(standardFont, displayText, position + offset, Color.Red);
            }
        }

        public void SetOffset(Vector2 offset)
        {
            this.offset = offset;
        }

        #region mouse
        protected Boolean IsMouseLeftClicked()
        {
            if (currentMouse.LeftButton == ButtonState.Released && previousMouse.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            return false;
        }

        protected Boolean IsMouseRightClicked()
        {
            if (currentMouse.RightButton == ButtonState.Released && previousMouse.RightButton == ButtonState.Pressed)
            {
                return true;
            }
            return false;
        }

        protected Boolean IsMouseLeftPressed()
        {
            if (currentMouse.LeftButton == ButtonState.Pressed)
            {
                return true;
            }
            return false;
        }

        protected Boolean IsMouseRightPressed()
        {
            if (currentMouse.RightButton == ButtonState.Pressed)
            {
                return true;
            }
            return false;
        }

        protected Boolean IsLeftClicked()
        {
            return (IsMouseLeftClicked() && IsTargeted());
        }

        protected Boolean IsRightClicked()
        {
            return (IsMouseRightClicked() && IsTargeted());
        }

        protected Boolean IsTargetLeftPressed()
        {
            return (IsMouseLeftPressed() && IsTargeted());
        }

        protected Boolean IsTargetRightPressed()
        {
            return (IsMouseRightPressed() && IsTargeted());
        }

        protected Boolean IsTargeted()
        {
            if (CollisionDetection.IsPointInsideRectangle(new Vector2(currentMouse.X, currentMouse.Y), collisionZone))
            {
                return true;
            }
            return false;
        }
        #endregion
    }
}
