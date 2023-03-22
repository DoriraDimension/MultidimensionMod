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
	public class SmileyDeath : ModProjectile
	{
		int timer = 0;
		public override void SetStaticDefaults()
		{
			Main.projFrames[Projectile.type] = 11; //This is an animated Projectile
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

			if (Projectile.frame == 7)
			{

			}
			if ((Projectile.frame == 11 && Projectile.frameCounter >= frameSpeed))
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
