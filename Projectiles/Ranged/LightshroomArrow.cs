using MultidimensionMod.Projectiles.Ranged;
using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace MultidimensionMod.Projectiles.Ranged
{
    public class LightshroomArrow : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.aiStyle = 1;
            Projectile.friendly = true;
            Projectile.arrow = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.timeLeft = 600;
            Projectile.light = 0.3f;
            Projectile.tileCollide = true;
            Projectile.extraUpdates = 1;
        }

        public override void AI()
        {

        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
        }

        public override void OnKill(int timeLeft)
        {
            Collision.HitTiles(Projectile.position + Projectile.velocity, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Item10, Projectile.position);
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D texture = ModContent.Request<Texture2D>("MultidimensionMod/Projectiles/Ranged/LightshroomArrow_Glow").Value;
            Vector2 drawOrigin = new(texture.Width / 2, texture.Height / 2);
            var effects = Projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;

            Main.EntitySpriteDraw(texture, Projectile.Center - Main.screenPosition, null, Projectile.GetAlpha(Color.White), Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
            return false;
        }
    }
}