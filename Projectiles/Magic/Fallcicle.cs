using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Magic
{
    internal class Fallcicle : ModProjectile
    {

        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Projectile.width = 14;
            Projectile.height = 14;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Magic;
            Projectile.tileCollide = true;
            Projectile.timeLeft = 350;
            Projectile.ownerHitCheck = true;
        }

        public override void OnKill(int timeLeft)
        {
             int dustIndex = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Ice, 0f, 0f, 100, default(Color), 2f);
             Main.dust[dustIndex].velocity *= 1.4f;
        }

        public override void AI()
        {
            Projectile.velocity.Y = 15;
        }
    }
}