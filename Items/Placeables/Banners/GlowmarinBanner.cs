using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.Banners
{
	public class GlowmarinBanner : ModItem
	{

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Otherworldly Glowmarin Banner");
			// Tooltip.SetDefault("A fish from another dimension, they have glowing organs all over their body, suggesting that they originally lived in deeper waters.");
		}

		public override void SetDefaults()
		{
			Item.width = 12;
			Item.height = 28;
			Item.maxStack = 99;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.rare = ItemRarityID.Blue;
			Item.value = Item.sellPrice(silver: 3);
			Item.createTile = ModContent.TileType<MonsterBanner>();
			Item.placeStyle = 3;
		}
	}
}