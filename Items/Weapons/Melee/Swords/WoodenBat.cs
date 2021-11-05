using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class WoodenBat : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Wooden Bat");
			Tooltip.SetDefault("Le Bonk\nLow chance to confuse enemies on hit.");
			DisplayName.AddTranslation(GameCulture.German, "Holz Schläger");
			Tooltip.AddTranslation(GameCulture.German, "Le Bonk\nGeringe Chance Gegner zu verwirren.");
		}

		public override void SetDefaults()
		{
			item.damage = 10;
			item.melee = true;
			item.width = 52;
			item.height = 52;
			item.useStyle = ItemUseStyleID.SwingThrow;
			item.useTime = 30;
			item.useAnimation = 30;
			item.knockBack = 4;
			item.value = Item.buyPrice(copper: 5);
			item.rare = ItemRarityID.White;
			item.UseSound = SoundID.Item1;

		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddRecipeGroup("Wood", 50);;
			recipe.AddTile(16);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			if (Main.rand.NextFloat() < .1500f)
				target.AddBuff(BuffID.Confused, 180);
		}
	}
}