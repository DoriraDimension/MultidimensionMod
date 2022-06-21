using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Magic
{
	internal class SpazzicFlame : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spazzic Flame");
		}

		public override void SetDefaults()
		{
			Projectile.width = 30;
			Projectile.height = 54;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.penetrate = 5;
		}

		public override void AI()
		{
			if (Projectile.timeLeft > 240)
				Projectile.timeLeft = 240;
		}

		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.Item8, Projectile.position);

			for (int i = 0; i < 10; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.CursedTorch, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
			Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y + 0f, 0f, 0f, ModContent.ProjectileType<SpazExplosion>(), (int)((double)((float)Projectile.damage) * 1.0), 0f, Main.myPlayer);
			for (int e = 0; e < 4; e++)
			{
				Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center, new Vector2(Main.rand.NextFloat(-3, 3), Main.rand.NextFloat(-9, 10)), ModContent.ProjectileType<SpazBall>(), (int)((double)((float)Projectile.damage) * 0.5f), 0f, Main.myPlayer);
			}
		}
	}

	internal class SpazExplosion : ModProjectile
	{
		public override string Texture => "MultidimensionMod/Projectiles/NoTexture";

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spazzic Explosion");
		}

		public override void SetDefaults()
		{
			Projectile.width = 100;
			Projectile.height = 100;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.penetrate = -1;
			Projectile.localNPCHitCooldown = -1;
		}

		public override void AI()
		{
			if (Projectile.timeLeft > 180)
				Projectile.timeLeft = 180;
			for (int i = 0; i < 10; i++)
			{
				int num104 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.CursedTorch, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
				Main.dust[num104].noGravity = true;
				Main.dust[num104].velocity.X *= 0.3f;
				Main.dust[num104].velocity.Y *= 0.3f;
			}
		}
	}

	internal class SpazBall : ModProjectile
	{
		public override string Texture => "MultidimensionMod/Projectiles/NoTexture";

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Spazzic Bolt");
		}

		public override void SetDefaults()
		{
			Projectile.width = 20;
			Projectile.height = 20;
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
			for (int i = 0; i < 10; i++)
			{
				int num104 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.CursedTorch, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
				Main.dust[num104].noGravity = true;
				Main.dust[num104].velocity.X *= 0.3f;
				Main.dust[num104].velocity.Y *= 0.3f;
			}
		}
	}
}
