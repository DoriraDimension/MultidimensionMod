using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Melee.Swords
{
	public class DecayFlyFriendly : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Friendly Decay Fly");
			Main.projFrames[Projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.Bee);
			AIType = ProjectileID.Bee;
		}

		public override bool PreKill(int timeLeft)
		{
			Projectile.type = ProjectileID.Bee;
			return true;
		}
	}
}