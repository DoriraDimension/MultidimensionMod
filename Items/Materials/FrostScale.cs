using MultidimensionMod.Tiles;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Materials
{
	public class FrostScale : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Frost Scale");
			Tooltip.SetDefault("The scale of a juvenile ice drake, its cold and soft.\nIce Drake nest underground until they become too big for the small ice caves.");
			DisplayName.AddTranslation(GameCulture.German, "Frostschuppe");
			Tooltip.AddTranslation(GameCulture.German, "Die Schuppe eines jungen Eis Draken, sie ist kalt und weich.\nEis Draken nisten im Untergrund bis sie zu groß werden für die kleinen Eishöhlen.");
		}

		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.value = Item.sellPrice(copper: 32);
			item.rare = ItemRarityID.Green;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<ManaInfusedSandstone>());
			recipe.AddIngredient(ModContent.ItemType<Dimensium>());
			recipe.AddTile(ModContent.TileType<DimensionalForge>());
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
