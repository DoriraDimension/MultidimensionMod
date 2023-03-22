using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.Audio;
using Terraria.ModLoader;

namespace MultidimensionMod.NPCs.FU
{
	internal class AshCloud : ModProjectile
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
			Projectile.timeLeft = 120;
		}

		public override void Kill(int timeLeft)
		{
		}

		public override void AI()
		{
			Projectile.velocity *= 0.98f;
		}

		public override void OnHitPlayer(Player target, Player.HurtInfo info)
		{
			target.AddBuff(BuffID.Frostburn2, 300);
        }
	}
}