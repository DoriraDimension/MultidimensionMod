using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace MultidimensionMod.NPCs.Bosses.Smiley
{
    public class Baller4 : ModProjectile
    {
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
            Projectile.tileCollide = false;
            Projectile.ignoreWater = false;
            Projectile.light = 0.4f;

        }
        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 12; k++)
            {
                Random a = new Random();

                SoundEngine.PlaySound(SoundID.Item93, Projectile.position);

                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.Shadowflame, (float)((a.Next() % 100) / 100), (float)((a.Next() % 100) / 100), 0, default, 1.5f);   //spawns dust behind it, this is a spectral light blue dust. 15 is the dust, change that to what you want.


            }

        }

        public override void AI()
        {
            Projectile.velocity *= 1.01f;
            Projectile.spriteDirection = -1 * Projectile.direction;

            //this is Projectile dust

            int DustID2 = Dust.NewDust(Projectile.position + Projectile.velocity, Projectile.width, Projectile.height, 112, Projectile.velocity.X * -0.1f, Projectile.velocity.Y * -0.1f, 0, default, 1.25f);   //spawns dust behind it, this is a spectral light blue dust lol
            Main.dust[DustID2].noGravity = true;


            //this make that the Projectile faces the right way
            Projectile.rotation = (float)Math.Atan2((double)Projectile.velocity.Y, (double)Projectile.velocity.X) + 1.57f;


            Projectile.localAI[0] += 1f;
            //Projectile.alpha = (int)Projectile.localAI[0] * 2;

            if (Projectile.localAI[0] > 10 * 60f) //Projectile time left before disappears
            {

                Projectile.Kill();
            }
            // Loop through the 20 animation frames, spending 15 ticks on each.
            int frameSpeed = 16;
            Projectile.frameCounter++;
            if (Projectile.frameCounter >= frameSpeed)
            {
                Projectile.frameCounter = 0;
                Projectile.frame++;
                if (Projectile.frame >= Main.projFrames[Projectile.type])
                {
                    Projectile.frame = 0;
                }
            }
        }

    }
}



