using MultidimensionMod.Rarities.Souls;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Souls
{
	public class SkeletonSoul : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Soul of Skeletron");
			// Tooltip.SetDefault("A curse, Skeletron was nothing more than the physical incarnation of a old curse,\nthis curse binds the one poor soul that has to carry it, to guard the dark dungeon for all eternity.\nA old clothier fell victim to this curse due to his own curiosity when he entered a place he wasnt supposed to enter.\nThe curses influence didn't just possess the old man but also created copies of its physical form to guard the dungeon on lower levels.\nThe origins of the curse lie deep within the dungeon itself, but only a fool would dare to find it.");
			ItemID.Sets.ItemIconPulse[Item.type] = true;
			ItemID.Sets.ItemNoGravity[Item.type] = true;
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 32;
			Item.rare = ModContent.RarityType<SkeletonSoulRarity>();
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Souls/SkeletonSoul").Value;
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