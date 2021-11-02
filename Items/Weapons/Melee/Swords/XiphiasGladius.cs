using MultidimensionMod.Items.Materials;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class XiphiasGladius : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Xiphias Gladius");
			Tooltip.SetDefault("A sword created from old blueprints found at the shores. The ancient depictions show it being used to fend off preditory ocean creatures.");
			DisplayName.AddTranslation(GameCulture.German, "Xiphias Gladius");
			Tooltip.AddTranslation(GameCulture.German, "Ein Schwert das mit alten Bauplänen erschaffen wurde welche am Ufer gefunden wurden. Die uralten Darstellungen zeigen wie es benutzt wurde um räuberische Ozeankreaturen abzuwehren.");
		}

		public override void SetDefaults()
		{
			item.damage = 94;
			item.melee = true;
			item.width = 42;
			item.height = 42;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = 1;
			item.knockBack = 4;
			item.autoReuse = true;
			item.value = Item.sellPrice(gold: 3);
			item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item1;
			item.crit = 11;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<TidalQuartz>(), 7);
			recipe.AddIngredient(ItemID.HallowedBar, 15);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}