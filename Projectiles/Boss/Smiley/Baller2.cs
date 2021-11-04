using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace ReplaceThisName
{

    public class Baller2 : ModProjectile
    {
        private int bounces;
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("SMILE!");
            Main.projFrames[projectile.type] = 1; //This is an animated projectile

        }
        public override void SetDefaults()
        {
            projectile.width = 26;
            projectile.height = 26;
            projectile.friendly = false;
            projectile.penetrate = 5;                       //this is the projectile penetration
            projectile.hostile = true;
            projectile.magic = true;                        //this make the projectile do magic damage
            projectile.tileCollide = true;                 //this make that the projectile does not go thru walls
            projectile.ignoreWater = false;
            projectile.light = 0.4f;    // projectile light

        }
        public override void Kill(int timeLeft)
        {
            for (int k = 0; k < 12; k++)
            {
                Random a = new Random();

                Main.PlaySound(SoundID.Item93, projectile.position);

                Dust.NewDust(projectile.position, projectile.width, projectile.height, DustID.Clentaminator_Red, (float)((a.Next() % 100) / 100), (float)((a.Next() % 100) / 100), 0, default, 1.5f);   //spawns dust behind it, this is a spectral light blue dust. 15 is the dust, change that to what you want.


            }

        }
        public override bool OnTileCollide(Vector2 oldVelocity)
        {
            if (projectile.velocity.X != oldVelocity.X)
            {
                projectile.position.X = projectile.position.X + projectile.velocity.X;
                projectile.velocity.X = -oldVelocity.X;
            }
            if (projectile.velocity.Y != oldVelocity.Y)
            {
                projectile.position.Y = projectile.position.Y + projectile.velocity.Y;
                projectile.velocity.Y = -oldVelocity.Y;
            }
            bounces++;
            if(bounces >6)
            {
                projectile.Kill();
            }
            return false; // return false because we are handling collision
        }
        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(BuffID.OnFire, 150);
            base.OnHitPlayer(target, damage, crit);
        }

        public override void AI()
        {
            projectile.spriteDirection = -1 * projectile.direction;

            //this is projectile dust
            if (projectile.tileCollide)
            {
             //   projectile.velocity *= -1;
            }
            int DustID2 = Dust.NewDust(projectile.position + projectile.velocity, projectile.width, projectile.height, DustID.DungeonSpirit, projectile.velocity.X * -0.1f, projectile.velocity.Y * -0.1f, 0, default, 1.25f);   //spawns dust behind it, this is a spectral light blue dust lol
            Main.dust[DustID2].noGravity = true;


            //this make that the projectile faces the right way
            projectile.rotation = (float)Math.Atan2((double)projectile.velocity.Y, (double)projectile.velocity.X) + 1.57f;


            projectile.localAI[0] += 1f;
            //projectile.alpha = (int)projectile.localAI[0] * 2;

            if (projectile.localAI[0] > 5 * 60f) //projectile time left before disappears
            {

                projectile.Kill();
            }
            // Loop through the 20 animation frames, spending 15 ticks on each.
            if (++projectile.frameCounter >= 30)
            {
                projectile.frameCounter = 0;
                if (++projectile.frame >= 20)
                {
                    projectile.frame = 0;
                }
            }
        }

    }
}



