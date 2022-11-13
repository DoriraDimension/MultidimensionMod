using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables
{
	public class FishLegacy : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Legacy of the Fish");
			Tooltip.SetDefault("It is said that the first thing Dorira ever created... was a low quality fish.");
		}

		public override void SetDefaults()
		{
			Item.width = 44;
			Item.height = 44;
			Item.maxStack = 9999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.rare = ItemRarityID.Expert;
			Item.value = Item.sellPrice(gold: 1);
			Item.createTile = ModContent.TileType<FishLegacyPlaced>();
		}
	}
}