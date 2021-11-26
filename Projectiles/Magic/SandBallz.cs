using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Magic
{
	internal class SandBallz : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("lioololol");
		}

		public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 18;
			projectile.friendly = true;
			projectile.ranged = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
			projectile.hide = false;
			projectile.penetrate = 3;
		}

		public override void AI()
		{
			projectile.velocity.Y = projectile.velocity.Y + 0.2f;
			if (projectile.velocity.Y > 16f)
			{
				projectile.velocity.Y = 16f;
			}
			projectile.rotation += 0.4f * (float)projectile.direction;

			int num104 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 32, projectile.velocity.X * 0.2f, projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
			Main.dust[num104].noGravity = true;
			Main.dust[num104].velocity.X *= 0.3f;
			Main.dust[num104].velocity.Y *= 0.3f;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			projectile.penetrate--;
			if (projectile.penetrate <= 0)
			{
				projectile.Kill();
			}
			else
			{
				Collision.HitTiles(projectile.position + projectile.velocity, projectile.velocity, projectile.width, projectile.height);
				Main.PlaySound(SoundID.Item10, projectile.position);
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.velocity.Y = -oldVelocity.Y;
				}
			}
			return false;
		}
	}
}
