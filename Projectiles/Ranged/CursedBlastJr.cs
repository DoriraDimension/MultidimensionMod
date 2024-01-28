using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.GameContent;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Ranged
{
	internal class CursedBlastJr : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			Main.projFrames[Projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			Projectile.width = 18;
			Projectile.height = 18;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = true;
			Projectile.timeLeft = 200;
		}

		public override void AI()
		{
			Player player = Main.LocalPlayer;
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
			if (++Projectile.frameCounter >= 5)
			{
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 4)
				{
					Projectile.frame = 0;
				}
			}
			Projectile.rotation = Projectile.velocity.ToRotation() - (float)Math.PI / 2f;
		}

		public override bool? CanHitNPC(NPC target)
		{
			return Projectile.timeLeft < 180 ? null : false;
		}

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            var effects = Projectile.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            int height = texture.Height / 4;
            int y = height * Projectile.frame;
            Rectangle rect = new(0, y, texture.Width, height);
            Vector2 drawOrigin = new(texture.Width / 2, Projectile.height / 2);

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, new Rectangle?(rect), Color.White, Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
            return false;
        }
    }
}