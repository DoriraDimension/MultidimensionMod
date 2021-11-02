using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.SwordProjectiles
{
	internal class Glowshard : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glowshard");
		}

		public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 18;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
			projectile.alpha = 255;
			projectile.hide = false;
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

			if (projectile.ai[0] >= 60f)
			{
				projectile.Kill();
			}
			projectile.direction = projectile.spriteDirection = projectile.velocity.X > 0f ? 1 : -1;
			projectile.rotation = projectile.velocity.ToRotation();
			if (projectile.velocity.Y > 16f)
			{
				projectile.velocity.Y = 16f;
			}

			if (Main.rand.Next(5) == 0) 
			{
				int choice = Main.rand.Next(3);
				if (choice == 0) 
				{
					choice = 15;
				}
				else if (choice == 1)
				{
					choice = 57;
				}
				else
				{
					choice = 58;
				}
				Dust.NewDust(projectile.position, projectile.width, projectile.height, choice, projectile.velocity.X * 0.25f, projectile.velocity.Y * 0.25f, 150, default(Color), 0.7f);
			}
		}
	}
}
