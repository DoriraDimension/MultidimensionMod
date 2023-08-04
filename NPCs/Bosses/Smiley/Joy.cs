using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace MultidimensionMod.NPCs.Bosses.Smiley
{

    public class Joy : ModProjectile
    {
        private int bounces;
        public override void SetStaticDefaults()
        {

        }
        public override void SetDefaults()
        {
            Projectile.width = 26;
            Projectile.height = 26;
            Projectile.friendly = false;
            Projectile.penetrate = 5;                       //this is the Projectile penetration
            Projectile.hostile = true;
            Projectile.tileCollide = true;                 //this make that the Projectile does not go thru walls
            Projectile.ignoreWater = false;
            Projectile.light = 0.4f;    // Projectile light

        }
        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 12; k++)
            {
                Random a = new Random();

                SoundEngine.PlaySound(SoundID.Item93, Projectile.position);

                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Ichor, (float)((a.Next() % 100) / 100), (float)((a.Next() % 100) / 100), 0, default, 1.5f);   //spawns dust behind it, this is a spectral light blue dust. 15 is the dust, change that to what you want.


            }

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
            if(bounces >6)
            {
                Projectile.Kill();
            }
            return false; // return false because we are handling collision
        }

        public override void AI()
        {
            Projectile.spriteDirection = -1 * Projectile.direction;

            //this is Projectile dust
            if (Projectile.tileCollide)
            {
             //   Projectile.velocity *= -1;
            }
            int DustID2 = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, DustID.Ichor, Projectile.velocity.X * -0.1f, Projectile.velocity.Y * -0.1f, 0, default, 1.25f);   //spawns dust behind it, this is a spectral light blue dust lol
            Main.dust[DustID2].noGravity = true;


            //this make that the Projectile faces the right way
            Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + 1.57f;


            Projectile.localAI[0] += 1f;
            //Projectile.alpha = (int)Projectile.localAI[0] * 2;

            if (Projectile.localAI[0] > 5 * 60f) //Projectile time left before disappears
            {

                Projectile.Kill();
            }
            // Loop through the 20 animation frames, spending 15 ticks on each.
            if (++Projectile.frameCounter >= 30)
            {
                Projectile.frameCounter = 0;
                if (++Projectile.frame >= 20)
                {
                    Projectile.frame = 0;
                }
            }
        }

    }
}



