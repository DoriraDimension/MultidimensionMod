using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Melee.Spears
{
	internal class DuskCrescent : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Dusk Crescent");
		}

		public override void SetDefaults()
		{
			Projectile.width = 22;
			Projectile.height = 22;
			Projectile.friendly = true;
			Projectile.DamageType = DamageClass.Melee;
			Projectile.ignoreWater = true;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
		}

		public override void Kill(int timeLeft)
		{

		}

		public override void AI()
		{
			if (Projectile.timeLeft > 180)
				Projectile.timeLeft = 180;
			Projectile.spriteDirection = Projectile.direction;
			Projectile.rotation += 0.6f * (float)Projectile.direction;
			Projectile.velocity *= 0.98f;
		}
	}
}