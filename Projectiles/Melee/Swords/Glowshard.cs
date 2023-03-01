using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Melee.Swords
{
	internal class Glowshard : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Glowshard");
		}

		public override void SetDefaults()
		{
			Projectile.width = 10;
			Projectile.height = 18;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.alpha = 255;
			Projectile.light = 0.6f;
			Projectile.hide = false;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255, 255, 255, 0) * (1f - (float)Projectile.alpha / 255f);
		}

		public override void Kill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.DD2_WitherBeastCrystalImpact, Projectile.position);

			for (int i = 0; i < 2; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 68, 0f, 0f, 68, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
		}

		public override void AI()
        {
			if (Projectile.timeLeft > 250)
				Projectile.timeLeft = 250;

			Projectile.alpha -= 25;
			if (Projectile.alpha < 100)
			{
				Projectile.alpha = 100;
			}

			if (Projectile.ai[0] >= 60f)
			{
				Projectile.Kill();
			}
			Projectile.direction = Projectile.spriteDirection = Projectile.velocity.X > 0f ? 1 : -1;
			Projectile.rotation = Projectile.velocity.ToRotation();
			if (Projectile.velocity.Y > 16f)
			{
				Projectile.velocity.Y = 16f;
			}
			int num104 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, 68, Projectile.velocity.X * 0.30f, Projectile.velocity.Y * 0.30f, 68, default(Color), 1f);
			Main.dust[num104].noGravity = true;
			Main.dust[num104].velocity.X *= 0.15f;
			Main.dust[num104].velocity.Y *= 0.15f;
		}

		public override bool PreDraw(ref Color lightColor)
		{
			Texture2D glowMask = ModContent.Request<Texture2D>("MultidimensionMod/Projectiles/Melee/Swords/Glowshard_Glow").Value;
			return true;
		}
	}
}
