using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Ranged
{
	internal class Eyeball : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Eyeball");
			Main.projFrames[projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			projectile.width = 14;
			projectile.height = 14;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.ignoreWater = false;
			projectile.tileCollide = true;
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 1; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 5, 0f, 0f, 100, default(Color), 2f); //blood
				Main.dust[dustIndex].velocity *= 1.4f;
			}
		}

		public override void AI()
		{
			if (projectile.timeLeft > 280)
				projectile.timeLeft = 280;

			if (++projectile.frameCounter >= 7)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= 4)
				{
					projectile.frame = 0;
				}
			}

			if (projectile.ai[0] >= 360f)
			{
				projectile.Kill();
			}
			projectile.direction = projectile.spriteDirection = projectile.velocity.X > 0f ? 1 : -1;
			projectile.rotation = projectile.velocity.ToRotation();
			if (projectile.velocity.Y > 16f)
			{
				projectile.velocity.Y = 16f;
			}

			if (projectile.spriteDirection == -1)
			{
				projectile.rotation += MathHelper.Pi;
			}
		}
	}
}