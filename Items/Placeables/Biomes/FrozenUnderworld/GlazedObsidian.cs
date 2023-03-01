using MultidimensionMod.Tiles.Biomes.FrozenUnderworld;
using MultidimensionMod.Items.Placeables.Biomes.FrozenUnderworld;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Biomes.FrozenUnderworld
{
	public class GlazedObsidian : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Glazed Obsidian");
			// Tooltip.SetDefault("schmobdi.");
		}

		public override void SetDefaults()
		{
			Item.width = 12;
			Item.height = 12;
			Item.maxStack = 9999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.createTile = ModContent.TileType<GlazedObsidianPlaced>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.Obsidian)
			.AddTile(TileID.IceMachine)
			.Register();
		}
	}
}