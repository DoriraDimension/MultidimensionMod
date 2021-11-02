using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Boomerangs
{
	public class FleshRipperProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Fleshho");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.BloodyMachete);
			aiType = ProjectileID.BloodyMachete;
		}

		public override bool PreKill(int timeLeft)
		{
			projectile.type = ProjectileID.BloodyMachete;
			return true;
		}
	}
}