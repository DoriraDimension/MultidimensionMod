using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Melee.Others
{
	public class GlowshardThrow : ModProjectile
	{

		internal Player Owner => Main.player[Projectile.owner];

		internal ref float Time => ref Projectile.ai[0];

		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Projectile.width = 30;
			Projectile.height = 30;
			Projectile.aiStyle = -1;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 70000;
			Projectile.ignoreWater = true;
			Projectile.extraUpdates = 1;
			Projectile.tileCollide = false;
			Projectile.ownerHitCheck = true;
		}

        public override bool? CanCutTiles()
        {
            return false;
        }

        public override void AI()
		{
			if (Owner.channel)
			{
				MouseStalking();
				Projectile.rotation += .3f;
				Vector2 position = Projectile.Center + (Projectile.rotation + (float)Math.PI / 4f).ToRotationVector2() * (float)Projectile.height * 0.45f;
				Time += 1f;
			}
			if (!Owner.channel)
            {
				Projectile.Kill();
            }
		}

		internal void MouseStalking()
		{
			if (Main.myPlayer == Projectile.owner)
			{
				if (Projectile.WithinRange(Main.MouseWorld, ((Vector2)(Projectile.velocity)).Length() * 0.7f))
				{
					Projectile.Center = Main.MouseWorld;
				}
				else
				{
					Projectile.velocity = (Projectile.velocity * 3f + Projectile.DirectionTo(Main.MouseWorld) * 19f) / 4f;
				}
				Projectile.netSpam = 0;
				Projectile.netUpdate = true;
			}
		}

		internal void ManipulatePlayerFields()
		{
			Owner.itemTime = 2;
			Owner.itemAnimation = 2;
		}

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Items/Weapons/Melee/Others/OceanicGlowshard_Glow").Value;
            Vector2 drawOrigin = new(texture.Width / 2, texture.Height / 2);
            var effects = Projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, null, Projectile.GetAlpha(Color.White), Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
            return false;
        }
    }
}