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
namespace MultidimensionMod.Projectiles.Boss.Smiley
{
	public class SmileyPhase2 : ModProjectile
	{
		int timer = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Smiley");
			Main.projFrames[projectile.type] = 13; //This is an animated projectile
		}

		public override void SetDefaults()
		{

			projectile.width = 88;
			projectile.height = 88;
			projectile.friendly = false;
			projectile.penetrate = 5;                       //this is the projectile penetration
			projectile.hostile = false;
			projectile.tileCollide = false;                 //this make that the projectile does not go thru walls
			projectile.ignoreWater = false;
			projectile.light = 0f;    // pro
		}
		public override void AI()
		{
			//Main.NewText("proj spawned");
			projectile.timeLeft = 5;
			int frameSpeed = 8; //How fast you want it to animate
			projectile.frameCounter++;
			if (projectile.frame == 0 && timer == 0)
			{
				projectile.frameCounter -= 10 ;
				timer = 1;
			}
			if (projectile.frame == 1 && timer == 1)
			{
				projectile.frameCounter -= 10 ;
				timer = 2;
			}
			if (projectile.frame == 2 && timer == 2)
			{
				projectile.frameCounter -= 10 ;
				timer = 3;
			}
			if (projectile.frame == 7 && timer == 3)
			{
				Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/SmileLaugh").WithVolume(1.2f).WithPitchVariance(-1.9f));

				projectile.frameCounter -= 45 ;
				timer = 4;
			}
			if (projectile.frame == 10 && timer == 4)
			{
				projectile.frameCounter -= 75 ;
				timer = 5;
			}
			if (projectile.frame == 12 && timer == 5)
			{
				projectile.frameCounter -= 15;
				timer = 6;
			}
			if ((projectile.frame == 12 && timer == 6) && projectile.frameCounter >= frameSpeed)
			{
				projectile.ai[1] = 1;

				projectile.Kill();
			}



			if (projectile.frameCounter >= frameSpeed)
			{
				projectile.frameCounter = 0;
				projectile.frame++;
				


				

			}
			
		}
		
	}

}
