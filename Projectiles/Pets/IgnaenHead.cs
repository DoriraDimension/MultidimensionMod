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
			projectile.CloneDefaults(ProjectileID.ZephyrFish);
			aiType = ProjectileID.ZephyrFish;
		}

		public override bool PreAI() {
			Player player = Main.player[projectile.owner];
			player.zephyrfish = false; 
			return true;
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
		}
	}
}