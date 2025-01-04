using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Graphics;
using Terraria.Graphics.Effects;

namespace MultidimensionMod.Biomes
{
    public class MireFog
    {
		public int fogOffsetX = 0;
		public float fadeOpacity = 0f;
		public float dayTimeOpacity = 0f;
		public bool backgroundFog = false;

		public MireFog(bool bg)
		{
			backgroundFog = bg;
		}

        public void Update(Texture2D texture)
        {
			if(Main.netMode == NetmodeID.Server || Main.dedServ) 
                return; 

			Player player = Main.LocalPlayer;
			bool inMire = player.InModBiome<TheShroudedMire>();

			fogOffsetX += 1;
			if(fogOffsetX >= texture.Width) fogOffsetX = 0;
			if(inMire)
			{
				fadeOpacity += 0.05f;
				if(fadeOpacity > 1f) fadeOpacity = 1f;
			}else
			{
				fadeOpacity -= 0.05f;
				if(fadeOpacity < 0f) fadeOpacity = 0f;
			}
			if(!backgroundFog)
			{
				dayTimeOpacity = Main.dayTime ? 0.8f : 0.5f;		
			}else
			{
				dayTimeOpacity = Main.dayTime ? 0.6f : 0.3f;
			}
        }

        public void Draw(Texture2D texture, bool dir, Color defaultColor, bool setSB = false)
        {
			if(fadeOpacity == 0f) 
                return;
            if(setSB) 
                Main.spriteBatch.Begin();
            Player player = Main.LocalPlayer;

			Color fogColor = GetAlpha(new Color(40,40,45), fadeOpacity * dayTimeOpacity);


            int minX = -texture.Width;
			int minY = -texture.Height;
			int maxX = Main.screenWidth + texture.Width;
			int maxY = Main.screenHeight + texture.Height;


            for (int i = minX; i < maxX; i += texture.Width)
            {
                for (int j = minY; j < maxY; j += texture.Height)
                {
                    if (player.position.Y < Main.worldSurface * 16.0)
                    {
                        Main.spriteBatch.Draw(texture, new Rectangle(i + (dir ? -fogOffsetX : fogOffsetX), j, texture.Width, texture.Height), null, fogColor, 0f, Vector2.Zero, SpriteEffects.None, 0f);
                    }
                }
            }
            Overlays.Scene.Draw(Main.spriteBatch, RenderLayers.All);
            if(setSB) 
                Main.spriteBatch.End();
        }

		public Color GetAlpha(Color newColor, float alph)
		{
			int alpha = 255 - (int)(255 * alph);
			float alphaDiff = (255 - alpha) / 255f;
			int newR = (int)(newColor.R * alphaDiff);
			int newG = (int)(newColor.G * alphaDiff);
			int newB = (int)(newColor.B * alphaDiff);
			int newA = newColor.A - alpha;
			if (newA < 0) newA = 0;
			if (newA > 255) newA = 255;		
			return new Color(newR, newG, newB, newA);
		}		
    }
}