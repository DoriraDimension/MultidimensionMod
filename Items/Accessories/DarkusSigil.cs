using MultidimensionMod.Items.Materials;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Tiles;
using MultidimensionMod.Rarities;
using MultidimensionMod.Common.Players;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
	public class DarkusSigil : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 38;
			Item.height = 34;
			Item.accessory = true;
			Item.value = Item.sellPrice(gold: 5);
			Item.rare = ItemRarityID.LightRed;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.GetCritChance(DamageClass.Generic) += 5;
			player.GetModPlayer<MDPlayer>().DarkusCrit = true;

		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Accessories/DarkusSigil_Glow").Value;
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