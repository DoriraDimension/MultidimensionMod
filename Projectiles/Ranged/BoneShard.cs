using MultidimensionMod.Dusts;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace MultidimensionMod.Projectiles.Ranged
{
    internal class BoneShard : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 4;
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0;
        }

        public override void SetDefaults()
        {
            Projectile.width = 10;
            Projectile.height = 10;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Ranged;
            Projectile.tileCollide = true;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            SoundEngine.PlaySound(SoundID.NPCHit2, Projectile.position);
            return true;
        }

        public int boneSloth = 0;

        public override void AI()
        {
            boneSloth++;
            Projectile.direction = Projectile.spriteDirection = Projectile.velocity.X > 0f ? 1 : -1;
            Projectile.rotation = Projectile.velocity.ToRotation() + MathHelper.PiOver2;
            if (Projectile.velocity.Y > 16f)
            {
                Projectile.velocity.Y = 16f;
            }
            if (boneSloth >= 5)
            {
                Projectile.velocity *= 0.88f;
            }
            Projectile.spriteDirection = Projectile.direction;
            if (boneSloth >= 14)
            {
                Projectile.alpha += 30;
            }
            if (boneSloth  >= 30)
            {
                Projectile.Kill();
            }
        }
    }
}