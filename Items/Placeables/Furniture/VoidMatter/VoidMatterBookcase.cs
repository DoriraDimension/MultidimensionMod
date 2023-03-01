using MultidimensionMod.Tiles.Furniture.VoidMatter;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Furniture.VoidMatter
{
	public class VoidMatterBookcase : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Void Matter Bookcase");
			// Tooltip.SetDefault("The knowledge found in these books is of great value, but it impossible to read for normal human beings.");
		}

		public override void SetDefaults()
		{
			Item.width = 28;
			Item.height = 34;
			Item.maxStack = 9999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.sellPrice(silver: 23);
			Item.createTile = ModContent.TileType<VoidMatterBookcasePlaced>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 20)
			.AddIngredient(ItemID.Book, 10)
			.AddTile(ModContent.TileType<EmptyKingsFabricatorPlaced>())
			.Register();
		}
	}
}