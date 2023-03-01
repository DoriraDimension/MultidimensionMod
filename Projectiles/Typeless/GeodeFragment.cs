using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Typeless
{
	internal class GeodeFragment : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Geode Fragment");
			Main.projFrames[Projectile.type] = 3;
		}

		public override void SetDefaults()
		{
			Projectile.width = 10;
			Projectile.height = 10;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Generic;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.penetrate = 3;
			Projectile.hide = false;
		}

		public override void AI()
		{
			if (Projectile.ai[0] != 1f)
			{
				Projectile.frame = Main.rand.Next(3);
				Projectile.ai[0] += 1f;
			}
			Projectile.ai[0] += 1f;
			if (Projectile.ai[0] >= 15f)
			{
				Projectile.ai[0] = 15f;
				Projectile.velocity.Y = Projectile.velocity.Y + 0.5f;
			}
			if (Projectile.velocity.Y > 16f)
			{
				Projectile.velocity.Y = 16f;
			}
			Projectile.rotation += 0.2f * (float)Projectile.direction;
		}

		public override bool OnTileCollide(Vector2 oldVelocity)
		{
			Projectile.penetrate--;
			if (Projectile.penetrate <= 0)
			{
				Projectile.Kill();
			}
			else
			{
				Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
				SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
				if (Projectile.velocity.X != oldVelocity.X)
				{
					Projectile.velocity.X = -oldVelocity.X;
				}
				if (Projectile.velocity.Y != oldVelocity.Y)
				{
					Projectile.velocity.Y = -oldVelocity.Y;
				}
			}
			return false;
		}

		public override void Kill(int timeLeft)
		{
			int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Dirt, 0f, 0f, 69, default(Color), 2f);
			Main.dust[dustIndex].velocity *= 0.5f;
			Main.dust[dustIndex].scale *= 0.5f;
		}
	}
}