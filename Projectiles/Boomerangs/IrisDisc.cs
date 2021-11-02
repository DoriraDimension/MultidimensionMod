using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Boomerangs
{
	public class IrisDisc : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Iris Disc");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.PossessedHatchet);
			aiType = ProjectileID.PossessedHatchet;
		}

		public override bool PreKill(int timeLeft)
		{
			projectile.type = ProjectileID.PossessedHatchet;
			return true;
		}
	}
}