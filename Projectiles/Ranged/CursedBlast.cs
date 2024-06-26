﻿using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.Audio;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace MultidimensionMod.Projectiles.Ranged
{
	public class CursedBlast : ModProjectile
	{
		public bool Eruption = false;
		public override void SetStaticDefaults()
		{

		}

		public override void SetDefaults()
		{
			Projectile.width = 22;
			Projectile.height = 22;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Ranged;
			Projectile.extraUpdates = 1;
			Projectile.penetrate = 2;
			Projectile.timeLeft = 180;
		}

		public int Child = 0;

		public override void AI()
		{
			Projectile.rotation += 0.2f * (float)Projectile.direction;
			Projectile.spriteDirection = Projectile.direction;
			if (Eruption)
            {
				Child++;
				Projectile.localAI[0] += 1f;
				float eruptionVelocityX = Main.rand.Next(-7, 7);
				float eruptionVelocityY = -10;
				SoundEngine.PlaySound(SoundID.Item34, Projectile.position);
				Projectile.penetrate = -1;
				Projectile.alpha = 255;
				Projectile.velocity.Y = 0;
				Projectile.velocity.X = 0;
				Projectile.friendly = false;
				if (Child == 20)
				{
					if (Projectile.owner == Main.myPlayer)
					{
						Projectile.NewProjectile(Projectile.GetSource_FromThis(), Projectile.Center.X, Projectile.Center.Y, eruptionVelocityX, eruptionVelocityY, ModContent.ProjectileType<CursedBlastJr>(), (int)((double)((float)Projectile.damage) * 0.4), 0, Projectile.owner);
						Projectile.netUpdate = true;
					}
					Child = 0;
				}
				if (Projectile.localAI[0] == 240f)
                {
					Projectile.Kill();
                }
			}
		}

		public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
			Eruption = true;
			Projectile.netUpdate = true;
		}

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Vector2 drawOrigin = new(texture.Width / 2, texture.Height / 2);
            var effects = Projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, null, Projectile.GetAlpha(Color.White), Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
            return false;
        }
    }
}