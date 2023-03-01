using MultidimensionMod.Tiles.Furniture.VoidMatter;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Furniture.VoidMatter
{
	public class VoidMatterSink : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Void Matter Sink");
			// Tooltip.SetDefault("");
		}

		public override void SetDefaults()
		{
			Item.width = 32;
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
			Item.createTile = ModContent.TileType<VoidMatterSinkPlaced>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 5)
			.AddIngredient(ItemID.WaterBucket)
			.Register();
		}
	}
}