using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Magic
{
	internal class MoonlightWave : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Moonlight Wave");
		}

		public override void SetDefaults()
		{
			projectile.width = 48;
			projectile.height = 48;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = false;
			projectile.light = 1.8f;
			projectile.hide = false;
		}

		public override void Kill(int timeLeft)
		{
			for (int i = 0; i < 5; i++)
			{
				int dustIndex = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, ModContent.DustType<Moondust>(), 0f, 0f, 100, default(Color), 2f);
				Main.dust[dustIndex].velocity *= 1.8f;
			}
		}

		public override void AI()
		{
			if (projectile.ai[0] >= 400f)
			{
				projectile.Kill();
			}
			projectile.direction = projectile.spriteDirection = projectile.velocity.X > 0f ? 1 : -1;
			projectile.rotation = projectile.velocity.ToRotation();
			if (projectile.velocity.Y > 16f)
			{
				projectile.velocity.Y = 16f;
			}
			if (projectile.spriteDirection == -1)
			{
				projectile.rotation += MathHelper.Pi;
			}
			for (int i = 0; i < 5; i++)
			{
				int num104 = Dust.NewDust(new Vector2(projectile.position.X, projectile.position.Y), projectile.width, projectile.height, ModContent.DustType<Moondust>(), projectile.velocity.X * 0.30f, projectile.velocity.Y * 0.30f, 68, default(Color), 1f);
				Main.dust[num104].noGravity = true;
				Main.dust[num104].velocity.X *= 0.15f;
				Main.dust[num104].velocity.Y *= 0.15f;
			}
		}

		public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
		{
			Texture2D glowMask = mod.GetTexture("Projectiles/Magic/MoonlightWave_Glow");
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