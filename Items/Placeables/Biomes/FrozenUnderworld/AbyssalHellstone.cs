using MultidimensionMod.Tiles.Biomes.FrozenUnderworld;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Biomes.FrozenUnderworld
{
	public class AbyssalHellstone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Abyssal Hellstone");
			Tooltip.SetDefault("Ice cold magic has turned this normally hot ore into a freezing rock.");
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
			Item.createTile = ModContent.TileType<AbyssalHellstonePlaced>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.Hellstone)
			.AddIngredient(ItemID.IceBlock)
			.AddTile(TileID.IceMachine)
			.Register();
		}
	}
}