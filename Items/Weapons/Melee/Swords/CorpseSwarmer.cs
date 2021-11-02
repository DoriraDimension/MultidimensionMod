using MultidimensionMod.Projectiles.SwordProjectiles;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Localization;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class CorpseSwarmer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Corpse Swarmer");
			Tooltip.SetDefault("a");
			DisplayName.AddTranslation(GameCulture.German, "Leichenschwärmer");
			Tooltip.AddTranslation(GameCulture.German, "a");
		}

		public override void SetDefaults()
		{
			item.damage = 51;
			item.melee = true;
			item.width = 64;
			item.height = 68;
			item.useTime = 21;
			item.useAnimation = 21;
			item.useStyle = 1;
			item.knockBack = 3;
			item.value = Item.sellPrice(gold: 2);
			item.rare = ItemRarityID.Pink;
			item.UseSound = SoundID.Item1;
			item.autoReuse = true;
			item.shoot = ModContent.ProjectileType<DecayFlyFriendly>();
			item.shootSpeed = 8f;
			item.crit = 4;
		}

		public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY, ref int type, ref int damage, ref float knockBack)
		{
			float speedX2 = speedX + (float)Main.rand.Next(-10, 11) * 0.40f;
			float speedY2 = speedY + (float)Main.rand.Next(-10, 11) * 0.40f;
			Projectile.NewProjectile(position.X, position.Y, speedX2, speedY2, type, damage, knockBack, player.whoAmI);
			if (Main.rand.NextBool(10))
			{
				Projectile.NewProjectile(position.X, position.Y, speedX2, speedY2, ModContent.ProjectileType<BigFly>(), (int)((double)damage * 1.5), knockBack, player.whoAmI);
			}
			return base.Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);

			{
				int numberProjectiles = 3 + Main.rand.Next(1);
				for (int i = 0; i < numberProjectiles; i++)
				{
					Vector2 perturbedSpeed = new Vector2(speedX, speedY).RotatedByRandom(MathHelper.ToRadians(30));
					Projectile.NewProjectile(position.X, position.Y, perturbedSpeed.X, perturbedSpeed.Y, type, damage, knockBack, player.whoAmI);
				}
				return Shoot(player, ref position, ref speedX, ref speedY, ref type, ref damage, ref knockBack);
			}
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			Projectile.NewProjectile(target.position.X + 0f + (float)Main.rand.Next(0, 151), player.position.Y + 0f, 0f, -6f, ModContent.ProjectileType<DecayFlyFriendly>(), (int)((double)((float)item.damage * player.meleeDamage) * 0.3), 0f, Main.myPlayer);
			Projectile.NewProjectile(target.position.X + 0f + (float)Main.rand.Next(0, 151), player.position.Y + 0f, 0f, -6f, ModContent.ProjectileType<BigFly>(), (int)((double)((float)item.damage * player.meleeDamage) * 0.3), 0f, Main.myPlayer);
		}

		public override void AddRecipes()
		{
			ModRecipe recipe = new ModRecipe(mod);
			recipe.AddIngredient(ModContent.ItemType<TheFly>());
			recipe.AddIngredient(ItemID.BeeKeeper);
			recipe.AddIngredient(ItemID.AdamantiteBar, 3);
			recipe.AddTile(134);
			recipe.SetResult(this);
			recipe.AddRecipe();
		}
	}
}