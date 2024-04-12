using MultidimensionMod.Common.Globals;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.GameContent;
using Terraria.Graphics.Effects;
using Terraria.ID;

namespace MultidimensionMod.Biomes
{
	public class MadnessMoonSky : CustomSky
	{
		public static bool Open = false;
		public override void Deactivate(params object[] args)
		{
			skyActive = false;
		}

		public override void Reset()
		{
			skyActive = false;
		}

		public override bool IsActive()
		{
			return skyActive || opacity > 0f;
		}

		public override Color OnTileColor(Color inColor)
		{
			Vector4 value = inColor.ToVector4();
			return new Color(Vector4.Lerp(value, Vector4.One, opacity * skyLight * 0.50f));
		}

		public override void Activate(Vector2 position, params object[] args)
		{
			skyActive = true;
		}

		private float moonAlpha = 0;
		public override void Draw(SpriteBatch spriteBatch, float minDepth, float maxDepth)
		{

			if (maxDepth >= 3E+38f && minDepth < 3E+38f)
			{
				string skyTexture = "MadnessMoonSky";
				string eyeTexture = "MadnessMoonEye";
				if (!Main.dayTime && MDWorld.MadnessMoon)
				{
					skyTexture = "MadnessMoonSky";
					eyeTexture = "MadnessMoonEye";
					spriteBatch.Draw(ModContent.Request<Texture2D>("MultidimensionMod/Backgrounds/" + skyTexture).Value, new Rectangle(0, 0, Main.screenWidth, Main.screenHeight), new Color(opacity * opacity, opacity * opacity, opacity * opacity, opacity));
				}

				if (Main.dayTime)
				{
					moonAlpha = 0;
				}
				if (!Main.dayTime && MDWorld.MadnessMoon)
				{
					if (moonAlpha < 1f)
						moonAlpha += 0.05f;
					else if (moonAlpha > 1f)
						moonAlpha = 1f;
					double bgTop = (int)((-Main.screenPosition.Y) / (Main.worldSurface * 16.0 - 600.0) * 200.0);
					if (Main.gameMenu || Main.netMode == NetmodeID.Server)
					{
						bgTop = -200;
					}
					int num23 = (int)(Main.time / 32400.0 * (Main.screenWidth + TextureAssets.Moon[Main.moonType].Value.Width * 2)) - TextureAssets.Moon[Main.moonType].Value.Width;
					int num24 = 0;
					Color white2 = Color.White;
					float num25 = 1f;
					float rotation2 = (float)(Main.time / 32400.0) * 2f - 7.3f;
					if (!Main.dayTime)
					{
						double num27;
						if (Main.time < 16200.0)
						{
							num27 = Math.Pow(1.0 - Main.time / 32400.0 * 2.0, 2.0);
							num24 = (int)(bgTop + num27 * 250.0 + 180.0);
						}
						else
						{
							num27 = Math.Pow((Main.time / 32400.0 - 0.5) * 2.0, 2.0);
							num24 = (int)(bgTop + num27 * 250.0 + 180.0);
						}
						num25 = (float)(1.2 - num27 * 0.4);
					}
					float num65 = 1f - Main.cloudAlpha * 1.5f;
					if (num65 < 0f)
					{
						num65 = 0f;
					}
					white2.R = (byte)(white2.R * num65);
					white2.G = (byte)(white2.G * num65);
					white2.B = (byte)(white2.B * num65);
					white2.A = (byte)(white2.A * num65);
					Texture2D moonTexture = ModContent.Request<Texture2D>("MultidimensionMod/Backgrounds/" + eyeTexture).Value;
					spriteBatch.Draw(moonTexture, new Vector2(num23, num24 + Main.moonModY), new Rectangle?(new Rectangle(0, 0, moonTexture.Width, moonTexture.Width)), white2 * opacity * moonAlpha, rotation2, new Vector2(moonTexture.Width / 2, moonTexture.Width / 2), num25, SpriteEffects.None, 0f);
				}
			}
		}
		public override void Update(GameTime gameTime)
		{
			if (skyActive)
			{
				if (opacity < 1f)
					opacity += 0.02f;
				if (opacity > 1f)
					opacity = 1f;

				if (!Main.dayTime)
					skyLight = Math.Min(1f, 0.005f + skyLight);
				if (Main.dayTime)
					skyLight = Math.Max(0f, skyLight - 0.005f);
			}
			else
			{
				if (opacity > 0f)
					opacity -= 0.02f;
				if (opacity < 0f)
					opacity = 0f;
			}
		}
		public override float GetCloudAlpha()
		{
			return (1f - opacity) * 0.97f + 0.03f;
		}

		private bool skyActive;

		private float opacity;
		private float skyLight;
	}

}
