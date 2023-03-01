using MultidimensionMod.Rarities.Souls;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Souls
{
	public class MetalWormSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Core of the Destroyer");
			// Tooltip.SetDefault("A long forgotten mech in shape of a worm that was lying dormant for years deep underground, it was now reactivated when the forces of light and darkness were unleashed.\nIt's only purpose is to tunnel through the ground and destroy everything in it's path.\nIt's creator remains unknown... for now...");
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 24;
			Item.rare = ModContent.RarityType<MetalWormSoulRarity>();
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Souls/MetalWormSoul").Value;
			spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					Item.position.X - Main.screenPosition.X + Item.width * 0.5f,
					Item.position.Y - Main.screenPosition.Y + Item.height - texture.Height * 0.5f
				),
				new Rectangle(0, 0, texture.Width, texture.Height),
				Color.White,
				rotation,
				texture.Size() * 0.5f,
				scale,
				SpriteEffects.None,
				0f
			);
		}
	}
}