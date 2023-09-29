using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;

namespace MultidimensionMod.Projectiles.Magic
{
	internal class MoonlightWave : ModProjectile
	{

		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Projectile.width = 48;
			Projectile.height = 48;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.light = 1.8f;
			Projectile.hide = false;
			Projectile.penetrate = -1;
		}

		public override void OnKill(int timeLeft)
		{
			for (int i = 0; i < 10; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.MagicMirror, 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.8f;
				Main.dust[dustIndex].alpha = 50;
				Main.dust[dustIndex].color = Color.MintCream;
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
				int dusto = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.MagicMirror, Projectile.velocity.X * 0.30f, Projectile.velocity.Y * 0.30f, 68, default(Color), 1f);
				Main.dust[dusto].noGravity = true;
				Main.dust[dusto].velocity.X *= 0.15f;
				Main.dust[dusto].velocity.Y *= 0.15f;
				Main.dust[dusto].color = Color.MintCream;
			}
		}

		public override bool PreDraw(ref Color lightColor)
		{
			Texture2D glowMask = ModContent.Request<Texture2D>("MultidimensionMod/Projectiles/Magic/MoonlightWave").Value;
			return true;
		}
	}
}