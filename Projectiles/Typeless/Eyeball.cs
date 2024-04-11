using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Typeless
{
	internal class Eyeball : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Eyeball");
			Main.projFrames[Projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			Projectile.width = 14;
			Projectile.height = 14;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Generic;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
		}

		public override void OnKill(int timeLeft)
		{
			for (int i = 0; i < 1; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Blood, 0f, 0f, 100, default(Color), 2f); //blood
				Main.dust[dustIndex].velocity *= 1.4f;
			}
		}

		public override void AI()
		{
			if (Projectile.timeLeft > 280)
				Projectile.timeLeft = 280;

			if (++Projectile.frameCounter >= 7)
			{
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 4)
				{
					Projectile.frame = 0;
				}
			}

			if (Projectile.ai[0] >= 360f)
			{
				Projectile.Kill();
			}
			Projectile.direction = Projectile.spriteDirection = Projectile.velocity.X > 0f ? 1 : -1;
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
			if (Projectile.velocity.Y > 16f)
			{
				Projectile.velocity.Y = 16f;
			}

            Projectile.spriteDirection = Projectile.direction;
        }
	}
}