using MultidimensionMod.Projectiles.Magic;
using System;
using System.IO;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Magic
{
	internal class Icicle : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Icicle");
		}

		public override void SetDefaults()
		{
			projectile.width = 22;
			projectile.height = 22;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.ignoreWater = false;
			projectile.tileCollide = true;
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.Item27, base.projectile.position);
			int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 67, 0f, 0f, 100, default(Color), 2f); //sinep
			Main.dust[dustIndex].velocity *= 1.4f;

			for (int i = 0; i < 4; i++)
			{
				projectile.rotation = projectile.velocity.ToRotation() + MathHelper.ToRadians(45f);
				int numProj = 2;
				float rotation = MathHelper.ToRadians(50f);
				Vector2 perturbedSpeed = base.projectile.velocity.RotatedBy(MathHelper.Lerp(0f - rotation, rotation, (float)(i / (numProj - 1))));
				Projectile.NewProjectile(base.projectile.Center, perturbedSpeed, ModContent.ProjectileType<Smallcicle>(), (int)((float)projectile.damage * 0.5f), projectile.knockBack, projectile.owner, 0f);
			}
		}

		public override void AI()
		{
			if (projectile.timeLeft > 180)
				projectile.timeLeft = 180;

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