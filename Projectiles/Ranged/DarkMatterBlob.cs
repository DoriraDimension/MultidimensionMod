using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Ranged
{
	internal class DarkMatterBlob : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Big Blob");
		}

		public override void SetDefaults()
		{
			projectile.width = 20;
			projectile.height = 20;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
			projectile.hide = false;
		}

		public override void AI()
		{
			projectile.velocity.Y = projectile.velocity.Y + 0.2f;
			if (projectile.velocity.Y > 10f)
			{
				projectile.velocity.Y = 10f;
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

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.NPCDeath1, projectile.position);

			for (int i = 0; i < 4; i++)
			{
				int a = Projectile.NewProjectile(projectile.Center.X, projectile.Center.Y - 25f, Main.rand.Next(-23, 9) * .25f, Main.rand.Next(-23, -5) * .25f, ModContent.ProjectileType<DarkMatterBlob2>(), (int)(projectile.damage * .5f), 0, projectile.owner);
				Main.projectile[a].tileCollide = true;
			}

			int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, ModContent.DustType<DarkDust>(), 0f, 0f, 100, default(Color), 2f);
			Main.dust[dustIndex].velocity *= 1.4f;
		}
	}
}
