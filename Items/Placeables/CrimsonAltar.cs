using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables
{
	public class CrimsonAltar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Crimson Altar");
			Tooltip.SetDefault("So you dont need to run to your local Crimson anymore.");
			DisplayName.AddTranslation(GameCulture.German, "Purpuraltar");
			Tooltip.AddTranslation(GameCulture.German, "So das du nicht mehr zu deinem lokalen Purpur rennen musst.");
		}

		public override void SetDefaults()
		{
			item.width = 22;
			item.height = 18;
			item.maxStack = 99;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.Green;
			item.value = Item.sellPrice(silver: 40);
			item.createTile = ModContent.TileType<Tiles.PlacedCrimsonAltar>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.TissueSample, 15);
			recipe.AddIngredient(836, 30);
			recipe.AddTile(26);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}