using MultidimensionMod.Tiles.Biomes.FrozenUnderworld;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Biomes.FrozenUnderworld
{
	public class AbyssalHellstoneBrick : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Abyssal Hellstone Brick");
			Tooltip.SetDefault("what the brick.");
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
			Item.createTile = ModContent.TileType<AbyssalHellstoneBrickPlaced>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ItemID.HellstoneBrick)
			.AddIngredient(ItemID.IceBrick)
			.AddTile(TileID.IceMachine)
			.Register();
		}
	}
}