using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Ranged
{
	internal class Mandible : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spinning Mandible");
		}

		public override void SetDefaults()
		{
			projectile.width = 16;
			projectile.height = 16;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.ignoreWater = false;
			projectile.tileCollide = true;
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 1; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 32, 0f, 0f, 100, default(Color), 2f); //sand
				Main.dust[dustIndex].velocity *= 1.4f;
			}
		}

		public override void AI()
		{

			if (projectile.ai[0] >= 270f)
			{
				projectile.Kill();
			}			
			projectile.rotation = 0.1f;
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