using MultidimensionMod.Tiles;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables
{
	public class Glowseed : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glowseed");
			Tooltip.SetDefault("A small glowing seed from another world. Grows a glowtree when placed instantly");
			DisplayName.AddTranslation(GameCulture.German, "Glühsamen");
			Tooltip.AddTranslation(GameCulture.German, "Ein kleiner leuchtender Samen aus einer anderen Welt. Lässt sofort einen Leuchtbaum wachsen wenn er platziert wird.");
		}

		public override void SetDefaults()
		{
			item.width = 14;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.Pink;
			item.value = Item.sellPrice(silver: 87);
			item.createTile = ModContent.TileType<OceanicGlowtree>();
		}

		public override void PostDrawInWorld(SpriteBatch spriteBatch, Color lightColor, Color alphaColor, float rotation, float scale, int whoAmI)
		{
			Texture2D texture = mod.GetTexture("Items/Placeables/Glowseed_Glow");
			spriteBatch.Draw
			(
				texture,
				new Vector2
				(
					item.position.X - Main.screenPosition.X + item.width * 0.5f,
					item.position.Y - Main.screenPosition.Y + item.height - texture.Height * 0.5f + 2f
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