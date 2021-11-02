using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.SwordProjectiles
{
	public class DecayFlyFriendly : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Friendly Decay Fly");
			Main.projFrames[projectile.type] = 4;
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Bee);
			aiType = ProjectileID.Bee;
		}

		public override bool PreKill(int timeLeft)
		{
			projectile.type = ProjectileID.Bee;
			return true;
		}
	}
}