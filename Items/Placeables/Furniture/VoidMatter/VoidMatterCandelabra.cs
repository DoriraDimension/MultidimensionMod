using MultidimensionMod.Tiles.Furniture.VoidMatter;
using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.Furniture.VoidMatter
{
	public class VoidMatterCandelabra : ModItem
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Void Matter Candelabra");
			// Tooltip.SetDefault("A romantic shine on a date in darkness.");
		}

		public override void SetDefaults()
		{
			Item.width = 32;
			Item.height = 32;
			Item.maxStack = 9999;
			Item.useTurn = true;
			Item.autoReuse = true;
			Item.useAnimation = 15;
			Item.useTime = 10;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.consumable = true;
			Item.rare = ItemRarityID.Orange;
			Item.value = Item.sellPrice(silver: 23);
			Item.createTile = ModContent.TileType<VoidMatterCandelabraPlaced>();
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 5)
			.AddIngredient(ModContent.ItemType<Dimensium>(), 3)
			.AddTile(ModContent.TileType<EmptyKingsFabricatorPlaced>())
			.Register();
		}
	}
}