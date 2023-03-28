using MultidimensionMod.Common.Players;
using MultidimensionMod.Items.Souls;
using MultidimensionMod.Items.Materials;
using MultidimensionMod.Tiles;
using MultidimensionMod.Rarities;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Accessories
{
	public class DiggerEngine : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 26;
			Item.height = 42;
			Item.accessory = true;
			Item.value = Item.sellPrice(gold: 12);
			Item.rare = ItemRarityID.Pink;
		}

		public override void UpdateAccessory(Player player, bool hideVisual)
		{
			player.pickSpeed += 0.50f;
			player.GetModPlayer<MDPlayer>().Probe = true;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.AncientChisel)
			.AddIngredient(ItemID.HallowedBar, 10)
			.AddIngredient(ItemID.SoulofMight, 7)
			.AddTile(TileID.MythrilAnvil)
			.Register();
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Accessories/DiggerEngine_Glow").Value;
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