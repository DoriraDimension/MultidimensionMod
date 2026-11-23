using Terraria.ID;
using Terraria;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using MultidimensionMod.Dusts;
using MultidimensionMod.Buffs.Debuffs;

namespace MultidimensionMod.Projectiles.Typeless
{

    internal class FairyDustCloud : ModProjectile
    {
        public override string Texture => "MultidimensionMod/Projectiles/NoTexture";

        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Projectile.width = 140;
            Projectile.height = 60;
            Projectile.friendly = true;
            Projectile.DamageType = DamageClass.Generic;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = true;
            Projectile.penetrate = -1;
            Projectile.localNPCHitCooldown = -1;
            Projectile.timeLeft = 90;
        }

        public override void AI()
        {
            for (int i = 0; i < 10; i++)
            {
                int num104 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, ModContent.DustType<PufferFartDust>(), Projectile.velocity.X * 0.2f, Projectile.velocity.Y * 0.2f, 100, Color.Pink, 1f);
                Main.dust[num104].noGravity = Main.rand.NextBool(3);
            }
            Rectangle rectangle = new Rectangle((int)Projectile.position.X, (int)Projectile.position.Y, Projectile.width, Projectile.height);
            for (int e = 0; e < Main.maxNPCs; e++)
            {
                NPC npc = Main.npc[e];
                if (rectangle.Intersects(npc.Hitbox) && !npc.friendly)
                {
                    npc.AddBuff(ModContent.BuffType<SparklyLungs>(), 420);
                }
            }
        }
    }
}