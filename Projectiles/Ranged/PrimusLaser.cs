﻿using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;

namespace MultidimensionMod.Projectiles.Ranged
{
	internal class PrimusLaser : ModProjectile
	{
		public int LaserCounter;

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Primus Laser");
			Main.projFrames[Projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			Projectile.width = 22;
			Projectile.height = 22;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.hide = false;
		}

		public override void AI()
		{
			Projectile.direction = Projectile.spriteDirection = Projectile.velocity.X > 0f ? 1 : -1;
			Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;

            Projectile.spriteDirection = Projectile.direction;

            LaserCounter++;
			if (LaserCounter >= 50)
            {
				SoundEngine.PlaySound(SoundID.Item33 with { Volume = 0.4f }, Projectile.position);
				if (Projectile.owner == Main.myPlayer)
				{
					Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y + 0f, Projectile.velocity.X, Projectile.velocity.Y, ModContent.ProjectileType<DestroyerDualLaser>(), (int)((double)((float)Projectile.damage) * 0.5), 0f, Main.myPlayer);
					Projectile.netUpdate = true;
				}
				LaserCounter = 0;
			}

			if (++Projectile.frameCounter >= 5)
			{
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 4)
				{
					Projectile.frame = 0;
				}
			}
		}

		public override void OnKill(int timeLeft)
		{
			SoundEngine.PlaySound(SoundID.NPCDeath14, Projectile.position);
			int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Torch, 0f, 0f, 6, default(Color), 2f);
			Main.dust[dustIndex].velocity *= 1.4f;
		}

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Projectiles/Ranged/PrimusLaser").Value;
            Texture2D glow = ModContent.Request<Texture2D>("MultidimensionMod/Projectiles/Ranged/PrimusLaser_Glow").Value;
            var effects = Projectile.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            int height = texture.Height / 4;
            int y = height * Projectile.frame;
            Rectangle rect = new(0, y, texture.Width, height);
            Vector2 drawOrigin = new(texture.Width / 2, Projectile.height / 2);

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, new Rectangle?(rect), lightColor, Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
            Main.EntitySpriteDraw(glow, Projectile.Center - Main.screenPosition, new Rectangle?(rect), Color.White, Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
            return false;
        }
    }
}