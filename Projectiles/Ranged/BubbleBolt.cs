using MultidimensionMod.Dusts;
using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Ranged
{
	internal class BubbleBolt : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Bubble Bolt");
			Main.projFrames[Projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			Projectile.width = 6;
			Projectile.height = 22;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.alpha = 255;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255, 255, 255, 0) * (1f - (float)Projectile.alpha / 255f);
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 1; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, ModContent.DustType<StormDust>(), 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
		}

		public override void AI()
		{
			Projectile.ai[0] += 1f;
			if (Projectile.ai[0] > 300f)
			{
				Projectile.alpha += 25;
				if (Projectile.alpha > 255)
				{
					Projectile.alpha = 255;
				}
			}
			else
			{
				Projectile.alpha -= 25;
				if (Projectile.alpha < 100)
				{
					Projectile.alpha = 100;
				}
			}
			Projectile.velocity /= 0.98f;

			if (++Projectile.frameCounter >= 5)
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
			Projectile.rotation = Projectile.velocity.ToRotation();
			if (Projectile.velocity.Y > 16f) {
				Projectile.velocity.Y = 16f;
			}

			if (Projectile.spriteDirection == -1) {
				Projectile.rotation += MathHelper.Pi;
			}

			if (Main.rand.Next(5) == 0)
			{
				int choice = Main.rand.Next(3);
				if (choice == 0)
				{
					choice = ModContent.DustType<StormDust>();
				}
				else if (choice == 1)
				{
					choice = ModContent.DustType<StormDust>();
				}
				else
				{
					choice = ModContent.DustType<StormDust>();
				}

				Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, choice, Projectile.velocity.X * 1f, Projectile.velocity.Y * 1f, 150, default(Color), 0.7f);
			}

		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Electrified, 900);
		}
	}
}
