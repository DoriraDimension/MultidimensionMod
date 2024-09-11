using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using Terraria.GameContent;

namespace MultidimensionMod.Projectiles.Magic
{
	internal class MoonlightWave : ModProjectile
	{

		public override void SetStaticDefaults()
		{
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 2;
        }

		public override void SetDefaults()
		{
			Projectile.width = 68;
			Projectile.height = 68;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.light = 1.8f;
			Projectile.hide = false;
			Projectile.penetrate = -1;
			Projectile.extraUpdates = 1;
            Projectile.timeLeft = 180;
            Projectile.usesLocalNPCImmunity = true;
            Projectile.localNPCHitCooldown = -1;
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

        public override bool? CanCutTiles()
        {
            return false;
        }

        public override void AI()
		{
			if (Projectile.ai[0] >= 400f)
			{
				Projectile.Kill();
			}
            Projectile.direction = Projectile.spriteDirection = Projectile.velocity.X > 0f ? 1 : -1;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            Projectile.spriteDirection = Projectile.direction;
            if (Projectile.velocity.Y > 16f)
			{
				Projectile.velocity.Y = 16f;
			}
		}

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D projectileTexture = TextureAssets.Projectile[Projectile.type].Value;
            Vector2 drawOrigin = new Vector2(projectileTexture.Width * 0.5f, Projectile.height * 0.5f);
            SpriteEffects spriteEffects = Projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color color = Color.White * ((float)(Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                Main.spriteBatch.Draw(projectileTexture, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale - k / (float)Projectile.oldPos.Length / 3, spriteEffects, 0f);
            }

            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            Vector2 drawOrigine = new(texture.Width / 2, texture.Height / 2);
            var effects = Projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, null, Projectile.GetAlpha(Color.White), Projectile.rotation, drawOrigine, Projectile.scale, effects, 0);
            return false;
        }
    }
}