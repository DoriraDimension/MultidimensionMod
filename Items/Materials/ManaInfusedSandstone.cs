using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class ManaInfusedSandstone : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Mana Sandstone");
			Tooltip.SetDefault("A special type of stone, found inside of Lesser Sand Elementals, you can feel the magic flowing through it.");
			DisplayName.AddTranslation(GameCulture.German, "Mana Durchtränkter Sandstein");
			Tooltip.AddTranslation(GameCulture.German, "Ein spezieller Stein der in Niederen Sand Elementaren gefunden wird, du kannst die Magie fühlen die durch ihn fließt.");
		}

		public override void SetDefaults()
		{
			item.width = 20;
			item.height = 24;
			item.maxStack = 999;
			item.value = Item.sellPrice(copper: 32);
			item.rare = ItemRarityID.Green;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<FrostScale>());
			recipe.AddIngredient(ModContent.ItemType<Dimensium>());
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
