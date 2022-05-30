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
			Projectile.width = 70;
			Projectile.height = 70;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Magic;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.penetrate = -1;
			Projectile.localNPCHitCooldown = -1;
		}

		public override void AI()
		{
			if (Projectile.timeLeft > 60)
				Projectile.timeLeft = 60;
		}
	}
}