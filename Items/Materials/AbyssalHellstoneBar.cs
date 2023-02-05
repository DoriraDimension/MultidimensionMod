using MultidimensionMod.Tiles.Biomes.FrozenUnderworld;
using MultidimensionMod.Items.Placeables.Biomes.FrozenUnderworld;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class AbyssalHellstoneBar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Abyssal Hellstone Bar");
			Tooltip.SetDefault("Cold to the touch.");
		}

		public override void SetDefaults()
		{
			Item.width = 12;
			Item.height = 12;
			Item.maxStack = 9999;
			//Item.useTurn = true;
			//Item.autoReuse = true;
			//Item.useAnimation = 15;
			//Item.useTime = 10;
			//Item.useStyle = ItemUseStyleID.Swing;
			//Item.consumable = true;
			//Item.createTile = ModContent.TileType<AbyssalHellstoneBarPlaced>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<AbyssalHellstone>(), 3)
			.AddIngredient(ModContent.ItemType<GlazedObsidian>())
			.Register();
		}
	}
}