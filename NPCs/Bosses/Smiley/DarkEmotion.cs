using MultidimensionMod.Dusts;
using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace MultidimensionMod.NPCs.Bosses.Smiley
{
    public class DarkEmotion : ModProjectile
    {
        private int bounces;
        public override void SetStaticDefaults()
        {
            Main.projFrames[Projectile.type] = 3;

        }
        public override void SetDefaults()
        {
            Projectile.width = 26;
            Projectile.height = 26;
            Projectile.friendly = false;
            Projectile.penetrate = 5; 
            Projectile.hostile = true;
            Projectile.tileCollide = true;
            Projectile.ignoreWater = false;
            Projectile.light = 0.4f;
            Projectile.timeLeft = 240;
        }
        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 12; k++)
            {
                Random a = new Random();

                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<VoidDustG>(), (float)((a.Next() % 100) / 100), (float)((a.Next() % 100) / 100), 0, default, 1.5f);
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, ModContent.DustType<VoidDustM>(), (float)((a.Next() % 100) / 100), (float)((a.Next() % 100) / 100), 0, default, 1.5f);
            }
        }

        public override void AI()
        {
            Projectile.spriteDirection = -1 * Projectile.direction;

            Player player = Main.player[0];
            float distance = 99999;
            for (int i = 0; i < Main.player.Length; i++)
            {
                if (Main.player[i].Distance(Projectile.Center) < distance && Main.player[i].active)
                {
                    player = Main.player[i];
                    distance = Main.player[i].Distance(Projectile.Center);
                }
            }

            if (Projectile.localAI[0] % 5 == 0)
            {
                Projectile.velocity += Vector2.Normalize(player.Center - Projectile.Center) * .85f;

                if (Projectile.velocity.X > 10 || Projectile.velocity.Y > 10)
                {
                    Projectile.velocity *= 0.95f;
                }
            }

            int DustID = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<VoidDustG>(), Projectile.velocity.X * -0.1f, Projectile.velocity.Y * -0.1f, 0, default, 1.25f);   //spawns dust behind it, this is a spectral light blue dust lol
            Main.dust[DustID].noGravity = true;
            int DustID2 = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, ModContent.DustType<VoidDustM>(), Projectile.velocity.X * -0.1f, Projectile.velocity.Y * -0.1f, 0, default, 1.25f);   //spawns dust behind it, this is a spectral light blue dust lol
            Main.dust[DustID2].noGravity = true;
            //this make that the Projectile faces the right way
            Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + 1.57f;
            Projectile.localAI[0] += 1f;
        }

        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (Projectile.velocity.X != oldVelocity.X)
            {
                Projectile.position.X = Projectile.position.X + Projectile.velocity.X;
                Projectile.velocity.X = -oldVelocity.X;
            }
            if (Projectile.velocity.Y != oldVelocity.Y)
            {
                Projectile.position.Y = Projectile.position.Y + Projectile.velocity.Y;
                Projectile.velocity.Y = -oldVelocity.Y;
            }
            bounces++;
            if (bounces > 6)
            {
                Projectile.Kill();
            }
            return false; // return false because we are handling collision
        }
    }
}



