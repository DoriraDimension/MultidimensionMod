using MultidimensionMod.Dusts;
using MultidimensionMod.Buffs.Debuffs;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Melee.Swords
{
	internal class VulkanusThrow : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Evil Ember, Vulkanus");
		}

		public override void SetDefaults()
		{
			Projectile.width = 72;
			Projectile.height = 72;
			Projectile.friendly = true;
			Projectile.aiStyle = -1;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.hide = false;
		}

		public override void Kill(int timeLeft)
		{
			Player player = Main.player[Projectile.owner];

		}

		public override void AI()
		{
			Player player = Main.player[Projectile.owner];
			player.heldProj = player.whoAmI;
			Projectile.rotation += .3f * Projectile.direction;
			Projectile.direction = Projectile.spriteDirection = Projectile.velocity.X > 0f ? 1 : -1;

			for (int i = 0; i < 5; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.CrimsonTorch, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.8f;
				Main.dust[dustIndex].alpha = 50;
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
        {
			target.AddBuff(ModContent.BuffType<BlazingSuffering>(), 360);
			SoundEngine.PlaySound(new("MultidimensionMod/Sounds/Custom/FireExplosion"), Projectile.position);
			int numberProjectiles = 8;
			for (int i = 0; i < numberProjectiles; i++)
			{
				Vector2 perturbedSpeed = new Vector2(Projectile.velocity.X / 2, Projectile.velocity.Y / 2).RotatedByRandom(MathHelper.ToRadians(360));
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, perturbedSpeed.X, perturbedSpeed.Y, ModContent.ProjectileType<VulkanusRock>(), damage, knockback, Main.myPlayer);
			}
			for (int i = 0; i < 25; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.CrimsonTorch, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
		}
	}
}