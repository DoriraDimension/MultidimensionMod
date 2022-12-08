using MultidimensionMod.Tiles.Furniture.VoidMatter;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Furniture.VoidMatter
{
	public class VoidMatterPlatform : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Void Matter Platform");
			Tooltip.SetDefault("A dark bridge that leads through the void, barely visible, beware not to fall.");
		}

		public override void SetDefaults()
		{
			Item.width = 24;
			Item.height = 16;
			Item.maxStack = 9999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.sellPrice(silver: 1);
			Item.createTile = ModContent.TileType<VoidMatterPlatformPlaced>();
		}

		public override void AddRecipes()
		{
			CreateRecipe(2)
			.AddIngredient(ModContent.ItemType<DarkMatterClump>())
			.Register();
		}
	}
}