using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Melee.Swords
{
	public class BigFly : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Big Decay Fly");
			Main.projFrames[Projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.GiantBee);
			AIType = ProjectileID.GiantBee;
		}

		public override bool PreKill(int timeLeft)
		{
			Projectile.type = ProjectileID.GiantBee;
			return true;
		}
	}
}