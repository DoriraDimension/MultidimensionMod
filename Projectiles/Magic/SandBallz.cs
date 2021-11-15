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
	}
}
