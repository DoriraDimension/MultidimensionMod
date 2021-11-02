using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables
{
	public class DemonAltar : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Demon Altar");
			Tooltip.SetDefault("So you dont need to run to your local Corruption anymore.");
			DisplayName.AddTranslation(GameCulture.German, "Dämonenaltar");
			Tooltip.AddTranslation(GameCulture.German, "So das du nicht mehr zu deinem lokalen Verderben rennen musst.");
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
			item.createTile = ModContent.TileType<Tiles.PlacedDemonAltar>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.ShadowScale, 15);
			recipe.AddIngredient(61, 30);
			recipe.AddTile(26);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}