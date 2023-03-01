using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Typeless
{
	internal class SandExplosion : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Sandsplosion");
			Main.projFrames[Projectile.type] = 5;
		}

		public override void SetDefaults()
		{
			Projectile.width = 60;
			Projectile.height = 60;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.penetrate = -1;
			Projectile.localNPCHitCooldown = -1;
		}

		public override void AI()
		{
			if (Projectile.timeLeft > 30)
				Projectile.timeLeft = 30;

			if (++Projectile.frameCounter >= 8)
			{
				Projectile.frameCounter = 0;
				if (++Projectile.frame >= 4)
				{
					Projectile.frame = 0;
				}
			}
		}
	}
}