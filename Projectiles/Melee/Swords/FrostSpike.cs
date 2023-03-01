using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Melee.Swords
{
	internal class FrostSpike : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Frost Spike");
		}

		public override void SetDefaults()
		{
			Projectile.width = 22;
			Projectile.height = 22;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Frostburn2, 240);
        }

		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Item27, base.Projectile.position);
			int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.BlueCrystalShard, 0f, 0f, 100, default(Color), 2f);
			Main.dust[dustIndex].velocity *= 1.4f;
		}

		public override void AI()
		{
			if (Projectile.timeLeft > 180)
				Projectile.timeLeft = 180;

			if (Projectile.ai[0] >= 360f)
			{
				Projectile.Kill();
			}
			Projectile.direction = Projectile.spriteDirection = Projectile.velocity.X > 0f ? 1 : -1;
			Projectile.rotation = Projectile.velocity.ToRotation();
			if (Projectile.velocity.Y > 16f)
			{
				Projectile.velocity.Y = 16f;
			}
			if (Projectile.spriteDirection == -1)
			{
				Projectile.rotation += MathHelper.Pi;
			}
		}
	}
}