using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.SwordProjectiles
{
	internal class Glowshard : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Glowshard");
		}

		public override void SetDefaults()
		{
			projectile.width = 10;
			projectile.height = 18;
			projectile.friendly = true;
			projectile.melee = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
			projectile.alpha = 255;
			projectile.light = 0.6f;
			projectile.hide = false;
		}

		public override Color? GetAlpha(Color lightColor)
		{
			return new Color(255, 255, 255, 0) * (1f - (float)projectile.alpha / 255f);
		}

		public override void Kill(int timeLeft)
		{
			Main.PlaySound(SoundID.DD2_WitherBeastCrystalImpact, projectile.position);

			for (int i = 0; i < 2; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 68, 0f, 0f, 68, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.4f;
			}
		}

		public override void AI()
        {
			if (projectile.timeLeft > 250)
				projectile.timeLeft = 250;

			projectile.alpha -= 25;
			if (projectile.alpha < 100)
			{
				projectile.alpha = 100;
			}

			if (projectile.ai[0] >= 60f)
			{
				projectile.Kill();
			}
			projectile.direction = projectile.spriteDirection = projectile.velocity.X > 0f ? 1 : -1;
			projectile.rotation = projectile.velocity.ToRotation();
			if (projectile.velocity.Y > 16f)
			{
				projectile.velocity.Y = 16f;
			}
			int num104 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, 68, projectile.velocity.X * 0.30f, projectile.velocity.Y * 0.30f, 68, default(Color), 1f);
			Main.dust[num104].noGravity = true;
			Main.dust[num104].velocity.X *= 0.15f;
			Main.dust[num104].velocity.Y *= 0.15f;
		}

		public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D glowMask = mod.GetTexture("Projectiles/SwordProjectiles/Glowshard_Glow");
			Rectangle frame = glowMask.Frame(1, Main.projFrames[projectile.type], 0, projectile.frame);
			frame.Height -= 1;
			float originOffsetX = (glowMask.Width - projectile.width) * 0.5f + projectile.width * 0.5f + drawOriginOffsetX;
			spriteBatch.Draw
			(
				 glowMask,
				 projectile.position - Main.screenPosition + new Vector2(originOffsetX + drawOffsetX, projectile.height / 2 + projectile.gfxOffY),
				 frame,
				 Color.White,
				 projectile.rotation,
				 new Vector2(originOffsetX, projectile.height / 2 - drawOriginOffsetY),
				 projectile.scale,
				 projectile.spriteDirection == -1 ? SpriteEffects.FlipHorizontally : SpriteEffects.None,
				 0f
			);
		}
	}
}
