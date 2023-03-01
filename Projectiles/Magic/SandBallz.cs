using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Magic
{
	internal class SandBallz : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Sand Ball");
		}

		public override void SetDefaults()
		{
			Projectile.width = 10;
			Projectile.height = 18;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.hide = false;
			Projectile.penetrate = 3;
		}

		public override void AI()
		{
			Projectile.velocity.Y = Projectile.velocity.Y + 0.2f;
			if (Projectile.velocity.Y > 16f)
			{
				Projectile.velocity.Y = 16f;
			}
			Projectile.rotation += 0.4f * (float)Projectile.direction;

			int num104 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 32, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
			Main.dust[num104].noGravity = true;
			Main.dust[num104].velocity.X *= 0.3f;
			Main.dust[num104].velocity.Y *= 0.3f;
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
	}
}
