using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace MultidimensionMod.Projectiles
{
	public class StormDroplet : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			DisplayName.SetDefault("Storm Droplet");
		}

		public override void SetDefaults()
		{
			projectile.CloneDefaults(ProjectileID.RainFriendly);
			aiType = ProjectileID.RainFriendly;
	    }

		public override bool PreKill(int timeLeft)
		{
			projectile.type = ProjectileID.RainFriendly;
			return true;
		}
	}
}