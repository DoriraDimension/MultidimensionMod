using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class FishronCleaver : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fishron Cleaver");
			Tooltip.SetDefault("A big cleaver, designed like a mutated ocean creature, maybe it was seen as a sign of strength.\nReleases typhoons on enemy hits.");
			DisplayName.AddTranslation(GameCulture.German, "Fishron Beil");
			Tooltip.AddTranslation(GameCulture.German, "Ein großes Beil, entworfen um wie eine mutierte Ozean Kreatur auszusehen, vielleicht wurde es als ein Zeichen der Stärke angesehen.\nVerschießt Taifune wenn gegner getroffen werden.");
		}

		public override void SetDefaults()
		{
			item.damage = 83;
			item.melee = true;
			item.width = 98;
			item.height = 94;
			item.useTime = 28;
			item.useAnimation = 28;
			item.useStyle = 1;
			item.knockBack = 6;
			item.value = Item.sellPrice(gold: 2);
			item.rare = ItemRarityID.Yellow;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.crit = 9;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			Projectile.NewProjectile(target.position.X + 0f + (float)Main.rand.Next(0, 151), player.position.Y + 0f, 0f, -6f, ProjectileID.Typhoon, (int)((double)((float)item.damage * player.meleeDamage) * 0.3), 0f, Main.myPlayer);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<FishCleaver>());
			recipe.AddIngredient(ModContent.ItemType<TidalQuartz>(), 15);
			recipe.needWater = true;
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}