using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;
using Microsoft.CodeAnalysis;
using MultidimensionMod.Base;
using Microsoft.Xna.Framework.Graphics;
using Terraria.GameContent;

namespace MultidimensionMod.Projectiles.Melee.Boomerangs
{
    internal class HellFlakeProj : ModProjectile
    {
        public override string Texture => "MultidimensionMod/Items/Weapons/Melee/Boomerangs/HellFlake";
        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Projectile.aiStyle = 3;
            Projectile.width = 35;
            Projectile.height = 35;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Melee;
            Projectile.tileCollide = true;
            Projectile.penetrate = 2;
            Projectile.timeLeft = 400;
        }

        public override void AI()
        {
            Player p = Main.player[Projectile.owner];
            BaseAI.AIBoomerang(Projectile, ref Projectile.ai, p.position, p.width, p.height, true, 20f, 30, Projectile.ai[0] == 0 ? 0.8f : 1.2f, .3f, false);
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damageDone)
        {
            for (int num468 = 0; num468 < 4; num468++)
            {
                num468 = Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, DustID.Ice, -Projectile.velocity.X * 0.2f,
                    -Projectile.velocity.Y * 0.2f, 100, default);
            }
            Projectile.netUpdate = true;
            target.AddBuff(BuffID.Chilled, 200);
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            for (int num468 = 0; num468 < 4; num468++)
            {
                num468 = Dust.NewDust(Projectile.Center, Projectile.width, Projectile.height, DustID.Ice, -Projectile.velocity.X * 0.2f,
                    -Projectile.velocity.Y * 0.2f, 100, default);
            }
            Collision.HitTiles(Projectile.position, Projectile.velocity, Projectile.width, Projectile.height);
            SoundEngine.PlaySound(SoundID.Dig, Projectile.position);
            Projectile.netUpdate = true;
            BaseAI.TileCollideBoomerang(Projectile, ref oldVelocity, true);
            return false;
        }

        public override bool PreDraw(ref Color lightColor)
        {
            Texture2D flake = TextureAssets.Projectile[Projectile.type].Value;
            Vector2 drawOrigin = new(flake.Width / 2, flake.Height / 2);
            SpriteEffects effects = Projectile.spriteDirection == 1 ? SpriteEffects.None : SpriteEffects.FlipHorizontally;
            Main.EntitySpriteDraw(flake, Projectile.Center - Main.screenPosition, null, Projectile.GetAlpha(lightColor), Projectile.rotation, drawOrigin, Projectile.scale, effects, 0);
            return false;
        }
    }
}