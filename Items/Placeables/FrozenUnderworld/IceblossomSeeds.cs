using MultidimensionMod.Tiles.FrozenUnderworld;
using Terraria.ModLoader;
using Terraria;
using Terraria.Localization;
using Terraria.ID;

namespace MultidimensionMod.Items.Placeables.FrozenUnderworld
{
	public class IceblossomSeeds : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Iceblossom Seeds");
			Tooltip.SetDefault("cold seeds that will grow into a Iceblossom when planted on Cold Ash");
			DisplayName.AddTranslation(GameCulture.German, "Eisblütensamen");
			Tooltip.AddTranslation(GameCulture.German, "Kalte Samen die zu einer Eisblüte heranwachsen wenn sie gepflanzt werden.");
		}

		public override void SetDefaults()
		{
			item.autoReuse = true;
			item.useTurn = true;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useAnimation = 15;
			item.useTime = 10;
			item.maxStack = 999;
			item.consumable = true;
			item.placeStyle = 0;
			item.width = 12;
			item.height = 14;
			item.value = 80;
			item.createTile = ModContent.TileType<Iceblossom>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ItemID.FireblossomSeeds, 1);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}