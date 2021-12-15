using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Pets
{
	public class IgnaenHead : ModProjectile
	{
		public override void SetStaticDefaults() {
			DisplayName.SetDefault("Ignaen's Head");
			Main.projFrames[projectile.type] = 6;
			Main.projPet[projectile.type] = true;
		}

		public override void SetDefaults() {
			projectile.width = 46;
			projectile.height = 46;
			projectile.tileCollide = false;
			projectile.friendly = true;
		}

		public override void PostDraw(SpriteBatch spriteBatch, Color lightColor)
        {
			Texture2D glowMask = mod.GetTexture("Projectiles/Pets/IgnaenHead_Glow");
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

		public override void AI()
		{
			Player player = Main.player[projectile.owner];
			MDPlayer modPlayer = player.GetModPlayer<MDPlayer>();
			if (player.dead)
			{
				modPlayer.IgnaenHead = false;
			}
			if (modPlayer.IgnaenHead)
			{
				projectile.timeLeft = 2;
			}

			int frameSpeed = 8;
			projectile.frameCounter++;
			if (projectile.frameCounter >= frameSpeed)
			{
				projectile.frameCounter = 0;
				projectile.frame++;
				if (projectile.frame >= Main.projFrames[projectile.type])
				{
					projectile.frame = 0;
				}
			}

			if (projectile.velocity.X > -0.1)
			{
				projectile.spriteDirection = -1;

			}
			else if (projectile.velocity.X < 0.1)
			{
				projectile.spriteDirection = 1;
			}

			Vector2 idlePosition = player.Center;
			idlePosition.Y -= 48f;

			Vector2 vectorToIdlePosition = idlePosition - projectile.Center;
			float distanceToIdlePosition = vectorToIdlePosition.Length();
			if (Main.myPlayer == player.whoAmI && distanceToIdlePosition > 1500f)
			{
				projectile.position = idlePosition;
				projectile.velocity *= 0.1f;
				projectile.netUpdate = true;
			}

			float speed = 8f;
			float inertia = 20f;

			if (distanceToIdlePosition > 300f)
			{
				// Speed up the minion if it's away from the player
				speed = 18f;
				inertia = 60f;
			}
			else
			{
				// Slow down the minion if closer to the player
				speed = 4f;
				inertia = 80f;
			}
			if (distanceToIdlePosition > 20f)
			{
				vectorToIdlePosition.Normalize();
				vectorToIdlePosition *= speed;
				projectile.velocity = (projectile.velocity * (inertia - 1) + vectorToIdlePosition) / inertia;
			}
		}
	}
}