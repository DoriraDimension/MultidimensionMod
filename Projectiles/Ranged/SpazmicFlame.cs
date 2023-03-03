using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Ranged
{
	public class SpazmicFlame : ModProjectile
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Projectile.width = 45;
			Projectile.height = 45; 
			Projectile.friendly = true; 
			Projectile.hostile = false; 
			Projectile.penetrate = 3;
			Projectile.timeLeft = 60; 
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.extraUpdates = 2;
			Projectile.scale = 0.3f;
			Projectile.alpha = 255;
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
				Dust dust = Dust.NewDustDirect(Projectile.position, Projectile.width, Projectile.height, DustID.CursedTorch, Projectile.velocity.X * 0.6f, Projectile.velocity.Y * 0.6f, 75);

				if (Main.rand.NextBool(3))
				{
					dust.noGravity = true;
					dust.scale *= 3f;
					dust.velocity.X *= 2f;
					dust.velocity.Y *= 2f;
				}
				dust.scale *= 1.5f;
				dust.velocity *= 1.2f;
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.CursedInferno, 240);
		}

		public override void OnHitPlayer(Player target, int damage, bool crit)
		{
			target.AddBuff(BuffID.CursedInferno, 240, false);
		}
	}
}
