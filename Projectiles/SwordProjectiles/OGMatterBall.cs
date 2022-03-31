using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.SwordProjectiles
{
	internal class OGMatterBall : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Matter Ball");
			Main.projFrames[projectile.type] = 3;
		}

		public override void SetDefaults()
		{
			projectile.width = 28;
			projectile.height = 28;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
			projectile.hide = false;
			projectile.penetrate = 2;
		}

		public override void AI()
        {
			if (projectile.timeLeft > 270)
				projectile.timeLeft = 270;

			if (++projectile.frameCounter >= 5)
			{
				projectile.frameCounter = 0;
				if (++projectile.frame >= 4)
				{
					projectile.frame = 0;
				}
			}
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
				projectile.ai[0] += 0.1f;
				if (projectile.velocity.X != oldVelocity.X)
				{
					projectile.velocity.X = -oldVelocity.X;
				}
				if (projectile.velocity.Y != oldVelocity.Y)
				{
					projectile.velocity.Y = -oldVelocity.Y;
				}
				Main.PlaySound(SoundID.Item10, projectile.position);
			}
			return false;
		}
	}
}
