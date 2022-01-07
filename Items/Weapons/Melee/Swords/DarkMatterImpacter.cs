using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class DarkMatterImpacter : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Matter Impacter");
			Tooltip.SetDefault("A massive dark matter sword used to hit enemies with a hefty swing.");
			DisplayName.AddTranslation(GameCulture.German, "Dunkle Materie Aufschlag");
			Tooltip.AddTranslation(GameCulture.German, "Ein massives dunkle materie Schwert das benutzt wird um Gegner mit einem heftigen Schwung zu treffen.");
		}

		public override void SetDefaults()
		{
			item.damage = 61;
			item.melee = true;
			item.width = 86;
			item.height = 86;
			item.useTime = 32;
			item.useAnimation = 32;
			item.useStyle = 1;
			item.knockBack = 8;
			item.value = Item.sellPrice(silver: 23);
			item.rare = 3;
			item.autoReuse = true;
			item.UseSound = SoundID.Item1;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 14);
			recipe.AddTile(26);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}