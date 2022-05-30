using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Melee.Boomerangs
{
	public class IrisDisc : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Iris Disc");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.PossessedHatchet);
			AIType = ProjectileID.PossessedHatchet;
		}

		public override bool PreKill(int timeLeft)
		{
			Projectile.type = ProjectileID.PossessedHatchet;
			return true;
		}
	}
}