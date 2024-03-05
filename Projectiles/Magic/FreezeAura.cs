using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using Terraria.ID;
using MultidimensionMod.Buffs.Debuffs;

namespace MultidimensionMod.Projectiles.Magic
{
    internal class FreezeAura : ModProjectile
    {
        public override string Texture => "MultidimensionMod/Projectiles/NoTexture";

        public override void SetStaticDefaults()
        {
        }

        public override void SetDefaults()
        {
            Projectile.width = 120;
            Projectile.height = 120;
            Projectile.friendly = true;
            Projectile.tileCollide = false;
            Projectile.penetrate = -1;
            Projectile.timeLeft = 1800;
            Projectile.ownerHitCheck = true;
        }

        public override bool? CanCutTiles()
        {
            return false;
        }

        public override void AI()
        {
            if (Main.rand.NextBool(2))
            {
                int num104 = Dust.NewDust(new Vector2(Projectile.position.X, Projectile.position.Y), Projectile.width, Projectile.height, DustID.IceTorch, Projectile.velocity.X * 0.30f, Projectile.velocity.Y * 0.30f, 200, default(Color), 3f);
                Main.dust[num104].noGravity = true;
                Main.dust[num104].velocity.X *= 0.15f;
                Main.dust[num104].velocity.Y *= 0.15f;
            }
            Rectangle rectangle = new Rectangle((int)Projectile.position.X, (int)Projectile.position.Y, Projectile.width, Projectile.height);
            for (int e = 0; e < Main.maxNPCs; e++)
            {
                NPC npc = Main.npc[e];
                if (rectangle.Intersects(npc.Hitbox))
                {
                    npc.AddBuff(BuffID.Frostburn, 360);
                }
            }
        }
    }
}