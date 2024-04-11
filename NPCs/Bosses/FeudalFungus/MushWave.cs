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
        //All 4 Mushshot variants reside in this file
        public override void SetStaticDefaults()
        {
            //DisplayName.SetDefault("Spore Blast");
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
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
            if (HomeOnce == 1)
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
            Vector2 drawOrigin = new Vector2(TextureAssets.Projectile[Projectile.type].Value.Width * 0.5f, Projectile.height * 0.5f);
            for (int k = 0; k < Projectile.oldPos.Length; k++)
            {
                Vector2 drawPos = Projectile.oldPos[k] - Main.screenPosition + drawOrigin + new Vector2(0f, Projectile.gfxOffY);
                Color color = Projectile.GetAlpha(lightColor) * ((Projectile.oldPos.Length - k) / (float)Projectile.oldPos.Length);
                Main.EntitySpriteDraw(TextureAssets.Projectile[Projectile.type].Value, drawPos, null, color, Projectile.rotation, drawOrigin, Projectile.scale, SpriteEffects.None, 0f);
            }
            return true;
        }
    }
}