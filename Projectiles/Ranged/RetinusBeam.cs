using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;

namespace MultidimensionMod.Projectiles.Ranged
{
	public class RetinusBeam : ModProjectile
	{
		public override string Texture => "MultidimensionMod/Projectiles/NoTexture";

		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("Retinus Beam");
		}

		public override void SetDefaults()
		{
			Projectile.width = 15;
			Projectile.height = 15;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.penetrate = 10;
			Projectile.extraUpdates = 100;
			Projectile.timeLeft = 180;
		}

		public override void AI()
		{
			Projectile.localAI[0] += 1f;
			if (Projectile.localAI[0] > 9f)
			{
				for (int A = 0; A < 10; A++)
				{
					Vector2 victor = Projectile.position;
					victor -= Projectile.velocity * (A * 0.25f);
					Projectile.alpha = 255;
					int num448 = Dust.NewDust(victor, 1, 1, DustID.RedTorch);
					Main.dust[num448].noGravity = true;
					Main.dust[num448].position = victor;
					Main.dust[num448].scale = (float)Main.rand.Next(70, 110) * 0.050f;
					Dust obj = Main.dust[num448];
					obj.velocity *= 0.2f;
				}
			}
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.immune[Projectile.owner] = 5;
		}
	}
}