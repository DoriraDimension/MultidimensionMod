using MultidimensionMod.Buffs.Debuffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ModLoader;
using Terraria.ID;

namespace MultidimensionMod.Projectiles.Ranged
{
	public class ShradesDemisePhase2 : ModProjectile
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Projectile.width = 50;
			Projectile.height = 50;
			Projectile.alpha = 255;
			Projectile.friendly = true;
			Projectile.hostile = false;
			Projectile.penetrate = 3;
			Projectile.timeLeft = 100;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.extraUpdates = 2;
			Projectile.scale = 0.5f;
		}

		public override void AI()
		{
			if (Projectile.timeLeft > 5)
			{
				Projectile.alpha -= 30;
			}
			else
				Projectile.alpha += 60;
			Projectile.scale += 0.028f;
			if (Main.rand.NextBool(15))
			{
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.BlueTorch, Projectile.velocity.X * 0.10f, Projectile.velocity.Y * 0.10f, 6);

				if (Main.rand.NextBool(3))
				{
					dust.noGravity = true;
					dust.scale *= 3f;
					dust.velocity.X *= 3f;
					dust.velocity.Y *= 3f;
				}
				dust.scale *= 1.5f;
				dust.velocity *= 1.2f;
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(ModContent.BuffType<BlazingSuffering>(), 180);
		}

		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			target.AddBuff(ModContent.BuffType<BlazingSuffering>(), 180);
		}
	}
}