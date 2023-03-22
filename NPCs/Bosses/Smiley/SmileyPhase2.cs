using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using MonoMod;

using Terraria.ID;
using Terraria.ModLoader;


//this is utterly fucking retarded
namespace MultidimensionMod.NPCs.Bosses.Smiley
{
	public class SmileyPhase2 : ModProjectile
	{
		int timer = 0;
		public override void SetStaticDefaults()
		{
			Main.projFrames[Projectile.type] = 13; //This is an animated Projectile
		}

		public override void SetDefaults()
		{

			Projectile.width = 88;
			Projectile.height = 88;
			Projectile.friendly = false;
			Projectile.penetrate = 5;                       //this is the Projectile penetration
			Projectile.hostile = false;
			Projectile.tileCollide = false;                 //this make that the Projectile does not go thru walls
			Projectile.ignoreWater = false;
			Projectile.light = 0f;    // pro
		}
		public override void AI()
		{
			//Main.NewText("proj spawned");
			Projectile.timeLeft = 5;
			int frameSpeed = 8; //How fast you want it to animate
			Projectile.frameCounter++;
			if (Projectile.frame == 0 && timer == 0)
			{
				Projectile.frameCounter -= 10 ;
				timer = 1;
			}
			if (Projectile.frame == 1 && timer == 1)
			{
				Projectile.frameCounter -= 10 ;
				timer = 2;
			}
			if (Projectile.frame == 2 && timer == 2)
			{
				Projectile.frameCounter -= 10 ;
				timer = 3;
			}
			if (Projectile.frame == 7 && timer == 3)
			{


				Projectile.frameCounter -= 45 ;
				timer = 4;
			}
			if (Projectile.frame == 10 && timer == 4)
			{
				Projectile.frameCounter -= 75 ;
				timer = 5;
			}
			if (Projectile.frame == 12 && timer == 5)
			{
				Projectile.frameCounter -= 15;
				timer = 6;
			}
			if ((Projectile.frame == 12 && timer == 6) && Projectile.frameCounter >= frameSpeed)
			{
				Projectile.ai[1] = 1;

				Projectile.Kill();
			}



			if (Projectile.frameCounter >= frameSpeed)
			{
				Projectile.frameCounter = 0;
				Projectile.frame++;
				


				

			}
			
		}
		
	}

}
