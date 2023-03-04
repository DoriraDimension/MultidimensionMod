using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MultidimensionMod.NPCs.Underworld
{
	internal class BurningAshCloud : ModProjectile
	{
		public override void SetStaticDefaults()
		{
		}

		public override void SetDefaults()
		{
			Projectile.width = 66;
			Projectile.height = 66;
			Projectile.hostile = true;
			Projectile.ignoreWater = false;
			Projectile.tileCollide = false;
			Projectile.penetrate = -1;
			Projectile.timeLeft = 60;
		}

		public override void Kill(int timeLeft)
		{
		}

		public override void AI()
		{
			Projectile.velocity *= 0.98f;
		}

		public override void OnHitNPC(NPC target, int damage, float knockback, bool crit)
		{
			target.AddBuff(BuffID.OnFire3, 300);
		}
	}
}