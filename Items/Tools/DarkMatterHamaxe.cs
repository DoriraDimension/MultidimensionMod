using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Tools
{
	public class DarkMatterHamaxe : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Matter Hamaxe");
			Tooltip.SetDefault("A dark matter hamaxe that could cut down dark trees if they would exist.");
			DisplayName.AddTranslation(GameCulture.German, "Dunkle Materie Hamaxt");
			Tooltip.AddTranslation(GameCulture.German, "Eine dunkle Materie Hamaxt die dunkle Bäume fällen könnte, würden sie existieren.");
		}

		public override void SetDefaults()
		{
			item.damage = 26;
			item.melee = true;
			item.width = 56;
			item.height = 50;
			item.useTime = 25;
			item.useAnimation = 25;
			item.axe = 30;
			item.hammer = 70;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.knockBack = 6;
			item.value = Item.sellPrice(silver: 6);
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 11);
			recipe.AddTile(26);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
