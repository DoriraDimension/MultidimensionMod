using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MultidimensionMod.Projectiles.Magic
{
	internal class NeuralWave : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Neural Wave");
		}

		public override void SetDefaults()
		{
			Projectile.width = 60;
			Projectile.height = 60;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.light = 0.5f;
			Projectile.hide = false;
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.PinkTorch, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.8f;
				Main.dust[dustIndex].alpha = 50;
			}
		}

		public override void AI()
		{
			if (Projectile.timeLeft > 300)
				Projectile.timeLeft = 300;

			if (Projectile.ai[0] >= 400f)
			{
				Projectile.Kill();
			}
			Projectile.direction = Projectile.spriteDirection = Projectile.velocity.X > 0f ? 1 : -1;
			Projectile.rotation = Projectile.velocity.ToRotation();
			if (Projectile.velocity.Y > 16f)
			{
				Projectile.velocity.Y = 16f;
			}
			if (Projectile.spriteDirection == -1)
			{
				Projectile.rotation += MathHelper.Pi;
			}
			for (int i = 0; i < 5; i++)
			{
				int num104 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.PinkTorch, Projectile.velocity.X * 0.30f, Projectile.velocity.Y * 0.30f, 68, default(Color), 1f);
				Main.dust[num104].noGravity = true;
				Main.dust[num104].velocity.X *= 0.15f;
				Main.dust[num104].velocity.Y *= 0.15f;
			}
		}
	}
}