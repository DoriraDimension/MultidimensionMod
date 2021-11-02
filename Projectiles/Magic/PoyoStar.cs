using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles.Magic
{
	public class PoyoStar : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Poyo Star");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.Starfury);
			aiType = ProjectileID.Starfury;
		}

		public override bool PreKill(int timeLeft)
		{
			projectile.type = ProjectileID.Starfury;
			return true;
		}
	}
}