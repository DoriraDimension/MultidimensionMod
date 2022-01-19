using MultidimensionMod.Tiles.FrozenUnderworld;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables.FrozenUnderworld
{
	public class ColdAshItem : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Cold Ash");
			Tooltip.SetDefault("Normal underworld ash that was cooled down by icy winds.");
			DisplayName.AddTranslation(GameCulture.German, "Kalte Asche");
			Tooltip.AddTranslation(GameCulture.German, "Normale Unterwelt Asche die von eisigen Winden gekühlt wurde.");
		}

		public override void SetDefaults()
		{
			item.width = 12;
			item.height = 12;
			item.maxStack = 999;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.createTile = ModContent.TileType<ColdAsh>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.AshBlock);
			recipe.AddTile(TileID.IceMachine);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
