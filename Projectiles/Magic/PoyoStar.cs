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
			Projectile.CloneDefaults(ProjectileID.FallingStar);
			AIType = ProjectileID.FallingStar;
		}

		public override bool PreKill(int timeLeft)
		{
			Projectile.type = ProjectileID.FallingStar;
			return true;
		}
	}
}