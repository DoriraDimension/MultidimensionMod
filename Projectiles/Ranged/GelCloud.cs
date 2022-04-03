using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Ranged
{
	public class GelCloud : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Gel Cloud");
		}

		public override void SetDefaults()
		{
			projectile.width = 65;
			projectile.height = 65;
			projectile.alpha = 255;
			projectile.friendly = true;
			projectile.penetrate = 3;
			projectile.timeLeft = 180;
			projectile.ignoreWater = false;
			projectile.tileCollide = true;
			projectile.ranged = true;
			projectile.extraUpdates = 2;
		}

		public override void AI()
		{
			Player player = Main.LocalPlayer;
			projectile.velocity *= 0.95f;
			projectile.ai[0] += 1f;
			if (projectile.ai[0] == 180f)
			{
				projectile.Kill();
			}
			if (projectile.ai[1] == 0f)
			{
				projectile.ai[1] = 1f;
				for (int num64 = 0; num64 < 30; num64++)
				{
					Dust.NewDust(projectile.position, projectile.width, projectile.height, 20, projectile.velocity.X, projectile.velocity.Y, 50);
				}
			}
		}
	}
}