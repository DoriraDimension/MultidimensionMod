using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.SwordProjectiles
{
	public class BigFly : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Big Decay Fly");
			Main.projFrames[projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.GiantBee);
			aiType = ProjectileID.GiantBee;
		}

		public override bool PreKill(int timeLeft)
		{
			projectile.type = ProjectileID.GiantBee;
			return true;
		}
	}
}