using MultidimensionMod.Base;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.CodeAnalysis;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace MultidimensionMod.NPCs.Bosses.FeudalFungus
{
    internal class MushWave : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
            Main.projFrames[Projectile.type] = 2;
        }

        public override void SetDefaults()
        {
            Projectile.width = 64;
            Projectile.height = 64;
            Projectile.friendly = false;
            Projectile.hostile = true;
            Projectile.ignoreWater = true;
            Projectile.penetrate = 1;
            Projectile.tileCollide = false;
            Projectile.alpha = 255;
            Projectile.timeLeft = 240;
            Projectile.extraUpdates = 1;
            Projectile.AL().CantHurtDapper = true;
        }

        private int HomeOnce = 0;

        public override void AI()
        {
            Projectile.alpha -= 40;
            HomeOnce++;
            Projectile.direction = Projectile.spriteDirection = Projectile.velocity.X > 0f ? 1 : -1;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            if (HomeOnce < 30)
            {
                Projectile.frame = 0;
            }
            else
                Projectile.frame = 1;
            if (HomeOnce == 30)
            {
                Player player = Main.LocalPlayer;
                Vector2 targetCenter = player.position;
                float ProjSpeed = 9f;
                Vector2 velocity = targetCenter - Projectile.Center;
                velocity.Normalize();
                velocity *= ProjSpeed;
                Projectile.velocity = velocity;
            }
        }

        public override void OnKill(int timeLeft)
        {
            for (int dust = 0; dust <= 3; dust++)
            {
                Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.GlowingMushroom, Projectile.oldVelocity.X * 0.5f, Projectile.oldVelocity.Y * 0.5f);
            }
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = TextureAssets.Projectile[Projectile.type].Value;
            var effects = Projectile.spriteDirection == -1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            int height = texture.Height / 2;
            int y = height * Projectile.frame;
            Rectangle rect = new(0, y, texture.Width, height);
            Vector2 drawOrigin = new(texture.Width / 2, Projectile.height / 2);

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, new Rectangle?(rect), Color.White, Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
            return false;
        }
    }
}