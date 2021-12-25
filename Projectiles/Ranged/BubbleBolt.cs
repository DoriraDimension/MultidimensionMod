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
			Main.projFrames[projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			projectile.width = 6;
			projectile.height = 22;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
			projectile.alpha = 255;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255, 255, 255, 0) * (1f - (float)projectile.alpha / 255f);
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item93, projectile.position);

			for (int i = 0; i < 1; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, ModContent.DustType<StormDust>(), 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
		}

		public override void AI()
		{
			projectile.ai[0] += 1f;
			if (projectile.ai[0] > 300f)
			{
				projectile.alpha += 25;
				if (projectile.alpha > 255)
				{
					projectile.alpha = 255;
				}
			}
			else
			{
				projectile.alpha -= 25;
				if (projectile.alpha < 100)
				{
					projectile.alpha = 100;
				}
			}
			projectile.velocity /= 0.98f;

			if (++projectile.frameCounter >= 5)
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
			if (projectile.velocity.Y > 16f) {
				projectile.velocity.Y = 16f;
			}

			if (projectile.spriteDirection == -1) {
				projectile.rotation += MathHelper.Pi;
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

				Dust.NewDust(projectile.position, projectile.width, projectile.height, choice, projectile.velocity.X * 1f, projectile.velocity.Y * 1f, 150, default(Color), 0.7f);
			}

		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.Electrified, 900);
		}
	}
}
