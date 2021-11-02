using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Magic
{
	public class Lophiiformes : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Lophiiformes");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.LostSoulFriendly);
			aiType = ProjectileID.LostSoulFriendly;
		}

		public override bool PreKill(int timeLeft)
		{
			projectile.type = ProjectileID.LostSoulFriendly;
			return true;
		}

		public override void AI()
		{
			projectile.localAI[0] += 1f;
			if (projectile.localAI[0] > 9f)
			{
				for (int i = 0; i < 4; i++)
				{
					Vector2 projectilePosition = projectile.position;
					projectilePosition -= projectile.velocity * ((float)i * 0.50f);
					projectile.alpha = 255;
					int dust = Dust.NewDust(projectilePosition, 1, 1, 68, 0f, 0f, 0, default(Color), 1f);
					Main.dust[dust].noGravity = true;
					Main.dust[dust].position = projectilePosition;
					Main.dust[dust].scale = (float)Main.rand.Next(70, 110) * 0.020f;
					Main.dust[dust].velocity *= 0.2f;
				}
			}
		}
	}
}