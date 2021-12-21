using MultidimensionMod.Items.Materials;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Ranged.Bows
{
	public class ToxotesArcus : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Toxotes Arcus");
			Tooltip.SetDefault("A bow created from old blueprints found at the shores. The ancient depictions show it being used to hunt ocean creatures for food.");
			DisplayName.AddTranslation(GameCulture.German, "Toxotes Arcus");
			Tooltip.AddTranslation(GameCulture.German, "Ein Bogen der mit alten Bauplänen erschaffen wurde welche am Ufer gefunden wurden. Die uralten Darstellungen zeigen wie er benutzt wurde um Ozeankreaturen für essen zu jagen.");
		}

		public override void SetDefaults()
		{
			item.damage = 105;
			item.ranged = true;
			item.width = 28;
			item.height = 46;
			item.useTime = 15;
			item.useAnimation = 15;
			item.useStyle = ItemUseStyleID.HoldingOut;
			item.noMelee = true;
			item.knockBack = 3;
			item.value = Item.sellPrice(gold: 1);
			item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item5;
			item.autoReuse = true;
			item.shoot = 10;
			item.shootSpeed = 25f;
			item.useAmmo = AmmoID.Arrow;
			item.crit = 9;
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<TidalQuartz>(), 6);
			recipe.AddIngredient(ItemID.HallowedBar, 13);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}
