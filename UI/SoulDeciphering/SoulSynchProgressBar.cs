using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.UI;

namespace MultidimensionMod.UI.SoulDeciphering
{
    public class SoulSynchProgressBar : UIElement
    {
        public float Progress { get; set; }
        private float displayedProgress;

        public SoulSynchProgressBar()
        {
            Width.Set(250f, 0f);
            Height.Set(16f, 0f);
        }

        protected override void DrawSelf(SpriteBatch spriteBatch)
        {
            CalculatedStyle dimensions = GetDimensions();

            Rectangle barRectangle = dimensions.ToRectangle();

            spriteBatch.Draw(Terraria.GameContent.TextureAssets.MagicPixel.Value, barRectangle, new Color(35, 25, 50));

            float progress = MathHelper.Clamp(displayedProgress, 0f, 1f);

            Rectangle fillRectangle = new Rectangle(barRectangle.X, barRectangle.Y, (int)(barRectangle.Width * progress), barRectangle.Height);

            //Draw the bar filling itself
            if (fillRectangle.Width > 0)
            {
                spriteBatch.Draw(Terraria.GameContent.TextureAssets.MagicPixel.Value, fillRectangle, Color.DarkRed);
            }
            //Draw a small highlight on top of the bar filling
            spriteBatch.Draw(Terraria.GameContent.TextureAssets.MagicPixel.Value, new Rectangle(barRectangle.X, barRectangle.Y, fillRectangle.Width, 2), Color.DarkSeaGreen);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            displayedProgress = MathHelper.Lerp(displayedProgress, Progress, 0.08f);

            // Snap to the target when sufficiently close.
            if (Math.Abs(displayedProgress - Progress) < 0.001f)
                displayedProgress = Progress;

        }

        public void Reset()
        {
            Progress = 0f;
            displayedProgress = 0f;
        }
    }
}