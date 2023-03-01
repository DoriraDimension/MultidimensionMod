using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class ManaInfusedSandstone : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 20;
			Item.height = 24;
			Item.maxStack = 9999;
			Item.value = Item.sellPrice(copper: 32);
			Item.rare = ItemRarityID.Green;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<FrostScale>())
			.AddIngredient(ModContent.ItemType<Dimensium>())
			.AddTile(ModContent.TileType<DimensionalForge>())
			.Register();
		}
	}
}
