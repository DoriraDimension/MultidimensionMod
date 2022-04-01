using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Magic
{
	internal class DarkBlast : ModProjectile
	{

		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Dark Blast");
		}

		public override void SetDefaults()
		{
			projectile.width = 70;
			projectile.height = 70;
			projectile.friendly = true;
			projectile.magic = true;
			projectile.ignoreWater = true;
			projectile.tileCollide = true;
			projectile.penetrate = -1;
			projectile.localNPCHitCooldown = -1;
		}

		public override void AI()
		{
			if (projectile.timeLeft > 60)
				projectile.timeLeft = 60;
		}
	}
}