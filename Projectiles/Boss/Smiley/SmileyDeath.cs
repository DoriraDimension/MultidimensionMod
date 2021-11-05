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
	public class SmileyDeath : ModProjectile
	{
		int timer = 0;
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Smiley");
			Main.projFrames[projectile.type] = 11; //This is an animated projectile
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

			if (projectile.frame == 7)
			{
				Main.PlaySound(mod.GetLegacySoundSlot(SoundType.Custom, "Sounds/Custom/SmileLaugh").WithVolume(1.2f).WithPitchVariance(-1.9f));

			}
			if ((projectile.frame == 11 && projectile.frameCounter >= frameSpeed))
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
