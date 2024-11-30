using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MultidimensionMod.Buffs.Debuffs;
using MultidimensionMod.Dusts;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.NPCs.MushBiomes
{
    internal class PufferFart : ModProjectile
    {
        public override string Texture => "MultidimensionMod/Projectiles/NoTexture";

        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Projectile.width = 180;
            Projectile.height = 180;
            Projectile.hostile = true;
            Projectile.ignoreWater = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 180;
        }

        public override void AI()
        {
            for (int i = 0; i < 4; i++)
            {
                int purple = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, ModContent.DustType<PufferFartDust>(), Projectile.velocity.X * 0.30f, Projectile.velocity.Y * 0.30f, 200, default(Color), 3f);
                Main.dust[purple].noGravity = true;
                Main.dust[purple].velocity.X *= 1f - Main.rand.NextFloat(0.3f);
                Main.dust[purple].velocity.Y *= 1f - Main.rand.NextFloat(0.3f);
            }
            Player player = Main.LocalPlayer;
            Rectangle rectangle = new Rectangle((int)Projectile.position.X, (int)Projectile.position.Y, Projectile.width, Projectile.height);
            if (rectangle.Intersects(player.Hitbox))
            {
                player.AddBuff(BuffID.Confused,240);
            }
        }
    }
}