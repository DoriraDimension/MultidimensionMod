using MultidimensionMod.Projectiles.Melee.Swords;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace MultidimensionMod.Items.Weapons.Melee.Swords
{
	public class CorpseSwarmer : ModItem
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Corpse Swarmer");
			Tooltip.SetDefault("Control the perfect swarm of rot loving flies.");
		}

		public override void SetDefaults()
		{
			Item.damage = 52;
			Item.DamageType = DamageClass.Melee;
			Item.width = 64;
			Item.height = 68;
			Item.useTime = 21;
			Item.useAnimation = 21;
			Item.useStyle = 1;
			Item.knockBack = 3;
			Item.value = Item.sellPrice(gold: 1);
			Item.rare = ItemRarityID.LightRed;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
			Item.shoot = ModContent.ProjectileType<DecayFlyFriendly>();
			Item.shootSpeed = 8f;
			Item.crit = 4;
		}

		public override bool Shoot(Player player, EntitySource_ItemUse_WithAmmo source, Vector2 position, Vector2 velocity, int type, int damage, float knockback)
		{
			float speedX2 = velocity.X + (float)Main.rand.Next(-10, 11) * 0.40f;
			float speedY2 = velocity.Y + (float)Main.rand.Next(-10, 11) * 0.40f;
			Projectile.NewProjectile(source, position.X, position.Y, speedX2, speedY2, type, damage, knockback, player.whoAmI);
			if (Main.rand.NextBool(10))
			{
				Projectile.NewProjectile(source, position.X, position.Y, speedX2, speedY2, ModContent.ProjectileType<BigFly>(), (int)((double)damage * 1.5), knockback, player.whoAmI);
			}
			

			for (int i = 0; i < 3; i++)
			{
				Vector2 newVelocity = velocity.RotatedByRandom(MathHelper.ToRadians(15));

				Projectile.NewProjectileDirect(source, position, newVelocity, ModContent.ProjectileType<DecayFlyFriendly>(), damage, knockback, player.whoAmI);
			}
			return false;
		}

		public override void OnHitNPC(Player player, NPC target, int damage, float knockback, bool crit)
		{
			Projectile.NewProjectile(Item.GetSource_ItemUse(player.HeldItem), target.position.X + 0f + (float)Main.rand.Next(0, 151), player.position.Y + 0f, 0f, -6f, ModContent.ProjectileType<DecayFlyFriendly>(), (int)((double)((float)Item.damage) * 0.3), 0f, Main.myPlayer);
			Projectile.NewProjectile(Item.GetSource_ItemUse(player.HeldItem), target.position.X + 0f + (float)Main.rand.Next(0, 151), player.position.Y + 0f, 0f, -6f, ModContent.ProjectileType<BigFly>(), (int)((double)((float)Item.damage) * 0.3), 0f, Main.myPlayer);
		}

		public override void AddRecipes()
		{
			CreateRecipe()
			.AddIngredient(ModContent.ItemType<TheFly>())
			.AddIngredient(ItemID.BeeKeeper)
			.AddIngredient(ItemID.AdamantiteBar, 3)
			.AddTile(134)
			.Register();
		}
	}
}