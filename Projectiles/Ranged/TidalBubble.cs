using Microsoft.Xna.Framework;
using Terraria;
using Terraria.Audio;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Ranged
{
	public class TidalBubble : ModProjectile
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Projectile.width = 20;
			Projectile.height = 20;
			Projectile.friendly = true;
			Projectile.tileCollide = false;
			Projectile.penetrate = 1;
			Projectile.alpha = 255;
			Projectile.timeLeft = 160;
			Projectile.DamageType = DamageClass.Ranged;
		}

		public override void AI()
		{
			Projectile.scale += 0.004f;
			if (Projectile.alpha <= 0)
			{
				Projectile.alpha = 0;
			}
			else if (Projectile.alpha > 50)
			{
				Projectile.alpha -= 30;
			}
			if (Projectile.timeLeft <= 100)
			{
				Projectile.ai[1] = 0f;
			}
			else
			{
				Projectile.velocity *= 0.980f;
			}
		}

		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(in SoundID.Item54, Projectile.position);
			int num190 = Main.rand.Next(5, 9);
			for (int num191 = 0; num191 < num190; num191++)
			{
				int num192 = Dust.NewDust(Projectile.Center, 0, 0, DustID.BubbleBurst_Blue, 0f, 0f, 100, default(Color), 1.0f);
				Main.dust[num192].velocity *= 0.8f;
				Main.dust[num192].position = Vector2.Lerp(Main.dust[num192].position, Projectile.Center, 0.5f);
				Main.dust[num192].noGravity = true;
			}
		}

		public override bool? CanHitNPC(NPC target)
		{
			return Projectile.timeLeft < 140 ? null : false;
		}
	}
}