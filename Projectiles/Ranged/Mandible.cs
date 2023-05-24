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
			// DisplayName.SetDefault("Spinning Mandible");
		}

		public override void SetDefaults()
		{
			Projectile.width = 16;
			Projectile.height = 16;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 1; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Sand, 0f, 0f, 100, default(Color), 2f); //sand
				Main.dust[dustIndex].velocity *= 1.4f;
			}
		}

		public override void AI()
		{
			if (Projectile.timeLeft > 260)
				Projectile.timeLeft = 260;

			if (Projectile.ai[0] >= 270f)
			{
				Projectile.Kill();
			}			
			Projectile.rotation = 0.1f;
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