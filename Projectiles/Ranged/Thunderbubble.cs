using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Ranged
{
	internal class Thunderbubble : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Thunderbubble");
			Main.projFrames[projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			projectile.width = 22;
			projectile.height = 18;
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

		public override void AI()
		{
			projectile.alpha -= 25;
			if (projectile.alpha < 100)
			{
				projectile.alpha = 100;
			}

			projectile.direction = projectile.spriteDirection = projectile.velocity.X > 0f ? 1 : -1;
			projectile.rotation = projectile.velocity.ToRotation();
			if (projectile.velocity.Y > 16f)
			{
				projectile.velocity.Y = 16f;
			}

			if (++projectile.frameCounter >= 5)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= 4)
				{
					projectile.frame = 0;
				}
			}

			projectile.velocity /= 0.98f;

			if (projectile.ai[0] >= 60f)
			{
				projectile.Kill();
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
			for (int i = 0; i < 5; i++)
			{
				int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 16f, Main.rand.Next(-10, 11) * .25f, Main.rand.Next(-10, -5) * .25f, ModContent.ProjectileType<BubbleBolt>(), (int)(projectile.damage * .5f), 0, projectile.owner);
				Main.projectile[a].tileCollide = true;
				Main.projectile[a].aiStyle = 1;
			}
		}
	}
}
