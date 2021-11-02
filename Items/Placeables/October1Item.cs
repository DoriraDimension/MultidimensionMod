using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Placeables
{
	public class October1Item : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Monument of the Eternal Bond");
			Tooltip.SetDefault("A monument, dedicated to the dimensional deities eternal soul bond.\n<3");
			DisplayName.AddTranslation(GameCulture.German, "Monument des ewigen Bunds");
			Tooltip.AddTranslation(GameCulture.German, "Ein Monument das dem ewigen Seelenbund der Dimensions Gottheiten.\n<3");
		}

		public override void SetDefaults()
		{
			item.width = 46;
			item.height = 16;
			item.maxStack = 1;
			item.useTurn = true;
			item.autoReuse = true;
			item.useAnimation = 15;
			item.useTime = 10;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.consumable = true;
			item.rare = ItemRarityID.Expert;
			item.value = Item.buyPrice(1, 0, 0, 0);
			item.createTile = ModContent.TileType<Tiles.October1>();
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(29);
			recipe.AddIngredient(ItemID.LovePotion);
			recipe.AddIngredient(ItemID.FragmentVortex, 7);
			recipe.AddIngredient(ItemID.FragmentSolar, 7);
			recipe.AddIngredient(ItemID.SoulofLight, 10);
			recipe.AddIngredient(ItemID.SoulofNight, 10);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}