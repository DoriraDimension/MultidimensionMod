using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class DarkMatterKnife : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Matter Knife");
			Tooltip.SetDefault("A small dark matter knife to stab your enemies with dark powers.");
			DisplayName.AddTranslation(GameCulture.German, "Dunkle Materie Messer");
			Tooltip.AddTranslation(GameCulture.German, "Ein kleines dunkle materie Messer um deine Gegner mit dunklen Kräften zu stechen.");
		}

		public override void SetDefaults()
		{
			item.damage = 26;
			item.melee = true;
			item.width = 50;
			item.height = 50;
			item.useTime = 18;
			item.useAnimation = 18;
			item.useStyle = 3;
			item.knockBack = 1f;
			item.value = Item.sellPrice(silver: 7);
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.crit = 5;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<DarkMatterClump>(), 9);
			recipe.AddTile(26);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}