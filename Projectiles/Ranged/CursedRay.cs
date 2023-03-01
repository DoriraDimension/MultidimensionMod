using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MultidimensionMod.Projectiles.Ranged
{
	public class CursedRay : ModProjectile
	{
		public override string Texture => "MultidimensionMod/Projectiles/NoTexture";

		public override void SetStaticDefaults()
		{
			// base.DisplayName.SetDefault("Blast");
		}

		public override void SetDefaults()
		{
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.penetrate = 5;
			Projectile.extraUpdates = 100;
			Projectile.timeLeft = 180;
		}

		public override void AI()
		{
			Projectile.localAI[0] += 1f;
			if (Projectile.localAI[0] > 9f)
			{
				for (int A= 0; A < 4; A++)
				{
					Vector2 victor = Projectile.position;
					victor -= Projectile.velocity * (A * 0.25f);
					Projectile.alpha = 255;
					int num448 = Dust.NewDust(victor, 1, 1, DustID.CursedTorch);
					Main.dust[num448].noGravity = true;
					Main.dust[num448].position = victor;
					Main.dust[num448].scale = (float)Main.rand.Next(70, 110) * 0.013f;
					Dust obj = Main.dust[num448];
					obj.velocity *= 0.2f;
				}
			}
		}
	}
}