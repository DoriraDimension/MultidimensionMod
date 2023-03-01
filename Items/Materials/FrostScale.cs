using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class FrostScale : ModItem
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Item.width = 12;
			Item.height = 12;
			Item.maxStack = 9999;
			Item.value = Item.sellPrice(copper: 32);
			Item.rare = ItemRarityID.Green;
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<ManaInfusedSandstone>())
			.AddIngredient(ModContent.ItemType<Dimensium>())
			.AddTile(ModContent.TileType<DimensionalForge>())
			.Register();
		}
	}
}
