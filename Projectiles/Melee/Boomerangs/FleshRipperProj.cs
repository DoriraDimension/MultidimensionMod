using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Melee.Boomerangs
{
	public class FleshRipperProj : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Flesh Ripper");
		}

		public override void SetDefaults()
		{
			Projectile.CloneDefaults(ProjectileID.BloodyMachete);
			AIType = ProjectileID.BloodyMachete;
		}

		public override bool PreKill(int timeLeft)
		{
			Projectile.type = ProjectileID.BloodyMachete;
			return true;
		}
	}
}