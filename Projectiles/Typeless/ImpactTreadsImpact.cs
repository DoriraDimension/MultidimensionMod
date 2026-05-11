using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;

namespace MultidimensionMod.Projectiles.Typeless
{

    internal class ImpactTreadsImpact : ModProjectile
    {
        public override string Texture => "MultidimensionMod/Projectiles/NoTexture";

        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Projectile.width = 160;
            Projectile.height = 30;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Generic;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.localNPCHitCooldown = -1;
            Projectile.timeLeft = 10;
        }

        public override void AI()
        {
            for (int i = 0; i < 20; i++)
            {
                int num104 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.Smoke, Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, default(Color), 2f);
                Main.dust[num104].noGravity = Main.rand.NextBool(3);
            }
        }
    }
}