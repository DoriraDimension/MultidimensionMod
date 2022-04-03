using System.Collections.Generic;
using MultidimensionMod.Projectiles.SwordProjectiles;
using MultidimensionMod.Items.Materials;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class BurningSaber : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Burning Saber");
			Tooltip.SetDefault("A saber that was restored from old relics, spawns small fire clouds on hit.");
			DisplayName.AddTranslation(GameCulture.German, "Brennender Säbel");
			Tooltip.AddTranslation(GameCulture.German, "Ein Säbel der aus alten Relikten restauriert wurde, spawnt kleine Feuerwolken when getroffen.");
		}

		public override void SetDefaults()
		{
			item.damage = 45;
			item.melee = true;
			item.width = 60;
			item.height = 68;
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = Item.sellPrice(silver: 90);
			item.rare = ItemRarityID.Orange;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;

		}

		public override void MeleeEffects(Player player, Rectangle hitbox)
		{
			if (Main.rand.NextBool(3))
			{
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, (6));
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			if (player.statLife >= player.statLifeMax2 / 2)
			{
				Projectile.NewProjectile(target.Center.X, target.Center.Y + 0f, 0f, 0f, ModContent.ProjectileType<Explosion>(), (int)((double)((float)item.damage) * 0.2), 0f, Main.myPlayer);
			}
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<OldMoltenBlade>());
			recipe.AddIngredient(ModContent.ItemType<OldMoltenGuard>());
			recipe.AddIngredient(ItemID.HellstoneBar, 12);
			recipe.AddTile(377);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}